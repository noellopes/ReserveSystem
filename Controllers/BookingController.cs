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

                return RedirectToAction(nameof(SelectRooms), new
                {
                    bookingId = bookingModel.ID_BOOKING,
                    checkInDate = bookingModel.CHECKIN_DATE,
                    checkOutDate = bookingModel.CHECKOUT_DATE
                });
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveRoomSelection(RoomBookingViewModel viewModel)
        {



            var selectedRooms = viewModel.RoomTypes.Where(rt => rt.SelectedQuantity > 0).ToList();
            if (selectedRooms.Count == 0)
            {
                TempData["ErrorMessage"] = "You must select at least one room.";
                return RedirectToAction(nameof(SelectRooms), new { bookingId = viewModel.BookingId });
            }


            foreach (var roomType in viewModel.RoomTypes)
            {
                if (roomType.SelectedQuantity > 0)
                {
                    var availableRooms = await _context.Room
                        .Where(r => r.RoomTypeId == roomType.RoomTypeId &&
                                   !_context.RoomBooking
                                       .Where(rb => rb.ID_ROOM == r.ID_ROOM)
                                       .Any(rb => _context.Booking
                                           .Where(b => b.ID_BOOKING == rb.ID_BOOKING)
                                           .Any(b => b.CHECKIN_DATE < viewModel.CheckInDate &&
                                                     b.CHECKOUT_DATE > viewModel.CheckInDate ||
                                                     b.CHECKIN_DATE > viewModel.CheckOutDate &&
                                                     b.CHECKOUT_DATE > viewModel.CheckOutDate
                                                     )))  
                        .CountAsync();

                    if (availableRooms < roomType.SelectedQuantity)
                    {
                        TempData["ErrorMessage"] = $"There are not enough {roomType.Type} rooms available for the selected dates.";
                        return RedirectToAction(nameof(SelectRooms), new { bookingId = viewModel.BookingId });
                    }
                }
            }
            foreach (var roomType in viewModel.RoomTypes.Where(rt => rt.SelectedQuantity > 0))
            {

                var availableRooms = await _context.Room
                    .Where(r => r.RoomTypeId == roomType.RoomTypeId &&
                               !_context.RoomBooking
                                   .Where(rb => rb.ID_ROOM == r.ID_ROOM)
                                   .Any(rb => _context.Booking
                                       .Where(b => b.ID_BOOKING == rb.ID_BOOKING)
                                       .Any(b => b.CHECKIN_DATE < viewModel.CheckInDate &&
                                                     b.CHECKOUT_DATE > viewModel.CheckInDate ||
                                                     b.CHECKIN_DATE > viewModel.CheckOutDate &&
                                                     b.CHECKOUT_DATE > viewModel.CheckOutDate
                                                     )))
                    .ToListAsync();


                var selectedRooms2 = availableRooms.Take(roomType.SelectedQuantity).ToList();

                foreach (var room in selectedRooms2)
                {
                    var roomBooking = new RoomBooking
                    {
                        ID_BOOKING = viewModel.BookingId,
                        ID_ROOM = room.ID_ROOM,
                        PERSON_NUMBER = roomType.RoomCapacity
                    };

                    _context.RoomBooking.Add(roomBooking);
                }
            }

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Room selection saved successfully!";
            return RedirectToAction(nameof(Details), new { id = viewModel.BookingId });

        }


    }


}
