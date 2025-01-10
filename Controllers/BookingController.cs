using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace ReserveSystem.Controllers
{


    //[Authorize]
    public class BookingController : Controller
    {
        private readonly ReserveSystemContext _context;
        private readonly ILogger<BookingController> _logger;

        public BookingController(ReserveSystemContext context, ILogger<BookingController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Booking
        public async Task<IActionResult> Index(int page = 1, string searchQuery = "")
        {


            /*
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get logged-in user ID

            var bookings = from b in _context.Booking.Include(b => b.Client) select b;

            

            var model = new BookingViewModel();

            model.BookingsIds = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = await bookings.CountAsync(),
            };



            model.Bookings = await bookings
                    .OrderBy(b => b.BOOKING_DATE)
                    .Skip((model.BookingsIds.CurrentPage - 1) * model.BookingsIds.PageSize)
                    .Take(model.BookingsIds.PageSize)
                    .ToListAsync();


            return View(model);


            */

            // Define o tamanho da página
            var pageSize = 9;

            // Cria a consulta inicial
            var bookings = from b in _context.Booking select b;

            // Aplica o filtro de busca, se houver
            if (!string.IsNullOrEmpty(searchQuery))
            {
                bookings = bookings.Where(b => b.ID_BOOKING.ToString().Contains(searchQuery));
            }

            // Passa o valor de busca para a ViewData para manter o valor no campo de busca
            ViewData["SearchQuery"] = searchQuery;

            // Calcula o número total de itens
            var totalItems = await bookings.CountAsync();

            // Calcula o número total de páginas
            var totalPages = (int)Math.Ceiling((decimal)totalItems / pageSize);

            // Verifica se a página solicitada é válida
            page = Math.Max(page, 1);
            if (page > totalPages && totalPages > 0) page = totalPages;

            // Obtém os itens da página atual
            var bookingPaged = await bookings
                .OrderBy(b => b.ID_BOOKING)  // Ordena por tipo ou outro critério
                .Skip((page - 1) * pageSize)  // Pula as páginas anteriores
                .Take(pageSize)  // Pega o número de itens correspondente ao tamanho da página
                .ToListAsync();

            // Passa as informações de paginação para a ViewData
            ViewData["TotalItems"] = totalItems;
            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = totalPages;

            // Retorna os dados para a view
            return View(bookingPaged);

        }

        // GET: Booking/Details/5
        public async Task<IActionResult> Details(int? id, bool savedNow = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingModel = await _context.Booking 
                .FirstOrDefaultAsync(m => m.ID_BOOKING == id);
            if (bookingModel == null)
            {
                    ViewBag.Entity = "Reserva";
                    ViewBag.Controller = "Booking";
                    ViewBag.Action = "Index";
                    return View("EntityNoLongerExists");
                
            }

            ViewBag.Saved = savedNow;
            return View(bookingModel);
        }

        // GET: Booking/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_CLIENT,CHECKIN_DATE,CHECKOUT_DATE,TOTAL_PERSONS_NUMBER")] Booking bookingModel)
        {
            if (ModelState.IsValid)
            {
                // Set default values for new bookings
                bookingModel.BOOKED = false;
                bookingModel.PAYMENT_STATUS = false;
                bookingModel.BOOKING_DATE = DateTime.Now;

                // Save the booking
                _context.Add(bookingModel);
                await _context.SaveChangesAsync();

                // Redirect to room selection
                return RedirectToAction(nameof(SelectRooms), new { bookingId = bookingModel.ID_BOOKING });
            }

            // If invalid, return to create view
            return View(bookingModel);
        }

        // GET: Booking/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var bookingModel = await _context.Booking.FindAsync(id);

          
            if (bookingModel == null)
            {
                ViewBag.Entity = "Booking";
                ViewBag.Controller = "Booking";
                ViewBag.Action = "Index";
                return View("EntityNoLongerExists");
            }
            ViewBag.CanUpdate = true;
            if ((bookingModel.CHECKIN_DATE.ToDateTime(TimeOnly.MinValue) - DateTime.Now).TotalDays < 3 && !bookingModel.CanDeleteOrUpdate())
            {
                ViewBag.CanUpdate = false;
            }
            ViewBag.bookingId = id;
            return View(bookingModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_BOOKING,ID_CLIENT,CHECKIN_DATE,CHECKOUT_DATE,BOOKING_DATE,TOTAL_PERSONS_NUMBER,BOOKED,PAYMENT_STATUS")] Booking bookingModel)
        {
            if (id != bookingModel.ID_BOOKING)
            {
                return NotFound();
            }


            if (!bookingModel.ValidDates("Edit"))
            {
                TempData["WarningMessage"] = "Dates are not valid!";
                return View(bookingModel);
            }



            if (ModelState.IsValid)
            {
                try
                {

                    var validBookingModel = await _context.Booking
                        .FirstOrDefaultAsync(m => m.ID_BOOKING == id);

                    validBookingModel.CHECKIN_DATE = bookingModel.CHECKIN_DATE;
                    validBookingModel.CHECKOUT_DATE = bookingModel.CHECKOUT_DATE;
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Booking updated successfully!";

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingModelExists(bookingModel.ID_BOOKING))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            
            return View(bookingModel);
        }

        // GET: Booking/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.CanDelete = true;
            if (id == null)
            {
                ViewBag.Entity = "BookingModel";
                ViewBag.Controller = "Booking";
                ViewBag.Action = "Index";
                return View("EntityNoLongerExists");
            }

            var bookingModel = await _context.Booking
                .FirstOrDefaultAsync(m => m.ID_BOOKING == id);
            if (bookingModel == null)
            {
                ViewBag.Entity = "BookingModel";
                ViewBag.Controller = "Booking";
                ViewBag.Action = "Index";
                return View("EntityNoLongerExists");
            }







            if ((bookingModel.CHECKIN_DATE.ToDateTime(TimeOnly.MinValue) - DateTime.Now).TotalDays < 3)
            {
                ViewBag.CanDelete = false;
            }

            return View(bookingModel);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookingModel = await _context.Booking.FindAsync(id);
            if (bookingModel != null)
            {
                _context.Booking.Remove(bookingModel);
            }
            ViewBag.Entity = "Reserva";
            ViewBag.Controller = "Booking";
            ViewBag.Action = "Index";

            await _context.SaveChangesAsync();
            return View("DeletedSuccess");
        }

        private bool BookingModelExists(int id)
        {
            return _context.Booking.Any(e => e.ID_BOOKING == id);
        }


        public async Task<IActionResult> SelectRooms(int bookingId)
        {
            // Busca os tipos de quartos disponÃ­veis
            var roomTypes = await _context.RoomType
                .Select(rt => new RoomTypeSelection
                {
                    RoomTypeId = rt.RoomTypeId,
                    Type = rt.Type,
                    RoomCapacity = rt.RoomCapacity,
                    Beds = rt.Beds,
                    HasView = rt.HasView,
                    AcessibilityRoom = rt.AcessibilityRoom
                })
                .ToListAsync();

            var viewModel = new RoomBookingViewModel
            {
                BookingId = bookingId,
                RoomTypes = roomTypes
            };

            return View(viewModel);
        }


        private async Task<bool> CheckRoomAvailability(RoomBookingViewModel viewModel, DateOnly checkinDate, DateOnly checkoutDate)
        {
            // Collect all the room IDs for the selected room types
            var selectedRoomTypeIds = viewModel.RoomTypes
                .Where(rt => rt.SelectedQuantity > 0)
                .Select(rt => rt.RoomTypeId)
                .ToList();

            // For each selected room type, check if any room is available for the given date range
            foreach (var roomTypeId in selectedRoomTypeIds)
            {
                // Get all rooms of the current room type
                var rooms = await _context.Room
                    .Where(r => r.RoomTypeId == roomTypeId)
                    .ToListAsync();

                // For each room, check if it is already booked for the selected dates
                foreach (var room in rooms)
                {
                    // Check if there's any existing booking for the room during the specified date range
                    var isRoomBooked = await _context.RoomBooking
                        .AnyAsync(rb => rb.ID_ROOM == room.ID_ROOM &&
                                        ((checkinDate >= rb.Booking.CHECKIN_DATE && checkinDate <= rb.Booking.CHECKOUT_DATE) ||
                                         (checkoutDate >= rb.Booking.CHECKIN_DATE && checkoutDate <= rb.Booking.CHECKOUT_DATE)));

                    if (!isRoomBooked)
                    {
                        // If a room is available for this room type and date range, we can book it
                        return true;
                    }
                }
            }

            // No rooms available for the selected dates
            return false;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveRoomSelection(RoomBookingViewModel viewModel)
        {
            try
            {
                var booking = await _context.Booking.FindAsync(viewModel.BookingId);
                if (booking == null)
                {
                    TempData["ErrorMessage"] = "Booking not found.";
                    return RedirectToAction(nameof(SelectRooms), new { bookingId = viewModel.BookingId });
                }

                // Step 1: Ensure at least one room is selected
                bool isAnyRoomSelected = viewModel.RoomTypes.Any(rt => rt.SelectedQuantity > 0);
                if (!isAnyRoomSelected)
                {
                    TempData["ErrorMessage"] = "You must select at least one room.";
                    return RedirectToAction(nameof(SelectRooms), new { bookingId = viewModel.BookingId });
                }

                // Step 2: Check for room availability
                bool isRoomAvailable = await CheckRoomAvailability(viewModel, booking.CHECKIN_DATE, booking.CHECKOUT_DATE);

                if (!isRoomAvailable)
                {
                    TempData["ErrorMessage"] = "No available rooms for the selected dates.";
                    return RedirectToAction(nameof(SelectRooms), new { bookingId = viewModel.BookingId });
                }

                // Step 3: Save the room selections
                foreach (var roomType in viewModel.RoomTypes.Where(rt => rt.SelectedQuantity > 0))
                {
                    for (int i = 0; i < roomType.SelectedQuantity; i++)
                    {
                        var roomBooking = new RoomBooking
                        {
                            ID_BOOKING = booking.ID_BOOKING,
                            ID_ROOM = _context.Room
                                .Where(r => r.RoomTypeId == roomType.RoomTypeId)
                                .Select(r => r.ID_ROOM)
                                .FirstOrDefault(), // Get one available room of this type
                            PERSON_NUMBER = roomType.RoomCapacity
                        };

                        _context.RoomBooking.Add(roomBooking);
                    }
                }

                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Quartos selecionados com sucesso!";
                return RedirectToAction(nameof(Details), new { id = viewModel.BookingId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving room selection");
                TempData["ErrorMessage"] = "An error occurred while saving.";
                return RedirectToAction(nameof(SelectRooms), new { bookingId = viewModel.BookingId });
            }
        }
    }


}
