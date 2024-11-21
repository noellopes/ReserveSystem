using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly ReserveSystemContext _context;

        public BookingController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: Booking
        public async Task<IActionResult> Index()
        {
            return View(await _context.Booking.ToListAsync());
        }

        // GET: Booking/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingModel = await _context.Booking 
                .FirstOrDefaultAsync(m => m.ID_BOOKING == id);
            if (bookingModel == null)
            {
                return NotFound();
            }

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
        public async Task<IActionResult> Create([Bind("ClientID,ID_BOOKING,CHECKIN_DATE,CHECKOUT_DATE,BOOKING_DATE,TOTAL_PERSONS_NUMBER,BOOKED,PAYMENT_STATUS")] BookingModel bookingModel)
        {
           
                if (ModelState.IsValid)
                {

                    bookingModel.BOOKED = false;
                    bookingModel.PAYMENT_STATUS = false;
                    bookingModel.BOOKING_DATE = DateTime.Now;
                    _context.Add(bookingModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Edit(int id, [Bind("ID_BOOKING,CHECKIN_DATE,CHECKOUT_DATE,BOOKING_DATE,TOTAL_PERSONS_NUMBER,BOOKED,PAYMENT_STATUS")] BookingModel bookingModel)
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

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingModelExists(int id)
        {
            return _context.Booking.Any(e => e.ID_BOOKING == id);
        }
    }
}
