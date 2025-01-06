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

        public BookingController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Booking
        public async Task<IActionResult> Index(int page = 1)
        {



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
        public async Task<IActionResult> Create([Bind("ID_CLIENT,ID_BOOKING,CHECKIN_DATE,CHECKOUT_DATE,BOOKING_DATE,TOTAL_PERSONS_NUMBER,BOOKED,PAYMENT_STATUS")] Booking bookingModel)
        {
           



                if (ModelState.IsValid)
                {
                   
                    bookingModel.BOOKED = false;
                    bookingModel.PAYMENT_STATUS = false;
                    bookingModel.BOOKING_DATE = DateTime.Now;
                    _context.Add(bookingModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { id = bookingModel.ID_BOOKING, savedNow = true });
                }



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
                ViewBag.Entity = "BookingModel";
                ViewBag.Controller = "Booking";
                ViewBag.Action = "Index";
                return View("EntityNoLongerExists");
            }
            return View(bookingModel);
        }

        // POST: Booking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_BOOKING,CHECKIN_DATE,CHECKOUT_DATE,BOOKING_DATE,TOTAL_PERSONS_NUMBER,BOOKED,PAYMENT_STATUS")] Booking bookingModel)
        {
            if (id != bookingModel.ID_BOOKING)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {

                    var existingBooking = await _context.Booking.FindAsync(id);

                    if (existingBooking == null)
                    {
                        ViewBag.Entity = "Reserva";
                        ViewBag.Controller = "Booking";
                        ViewBag.Action = "Index";
                        return View("EntityNoLongerExists");
                    }


                    _context.Update(bookingModel);
                    await _context.SaveChangesAsync();
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
    }


}
