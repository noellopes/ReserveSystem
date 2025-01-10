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
    public class BookingsController : Controller
    {
        private readonly ReserveSystemUsersDbContext _context;

        public BookingsController(ReserveSystemUsersDbContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> ViewBookingLog(int page = 1, DateOnly? beginDate = null, DateOnly? endDate = null)
        {
            var bookings = from b in _context.Booking select b;

            if(endDate!= null && beginDate != null)
            {
                if (endDate >= beginDate)
                {
                    var beginDateTime = beginDate.Value.ToDateTime(TimeOnly.MinValue);
                    var endDateTime = endDate.Value.ToDateTime(TimeOnly.MinValue);
                    bookings = bookings.Where(b => (b.CheckinDate.Date <= beginDateTime && beginDateTime > b.CheckoutDate.Date) || (b.CheckinDate.Date >= endDateTime && b.CheckoutDate.Date > endDateTime));
                  
                }
                if (endDate < beginDate)
                {
                    var beginDateTime = beginDate.Value.ToDateTime(TimeOnly.MinValue);
                    var endDateTime = endDate.Value.ToDateTime(TimeOnly.MinValue);
                    bookings = bookings.Where(b => (b.CheckinDate.Date <= endDateTime && endDateTime > b.CheckoutDate.Date) || (b.CheckinDate.Date >= beginDateTime && b.CheckoutDate.Date > beginDateTime));

                }
            }else if( (beginDate == null && endDate != null) || (beginDate != null && endDate == null))
            {
                if (beginDate == null)
                {
                    var selectedDateTime = endDate.Value.ToDateTime(TimeOnly.MinValue);
                    bookings = bookings.Where(b => b.CheckinDate.Date == selectedDateTime || selectedDateTime == b.CheckoutDate.Date);
                }
                if (endDate == null)
                {
                    var selectedDateTime = beginDate.Value.ToDateTime(TimeOnly.MinValue);
                    bookings = bookings.Where(b => b.CheckinDate.Date == selectedDateTime || selectedDateTime == b.CheckoutDate.Date);
                }
            }

            
            var model = new BookingViewModel();

            model.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = await bookings.CountAsync(),
            };

            model.Bookings = await bookings
                .OrderBy(s => s.CheckinDate)
                .Skip((model.PagingInfo.CurrentPage - 1) * model.PagingInfo.PageSize)
                .Take(model.PagingInfo.PageSize)
                .ToListAsync();

            model.BeginDate = beginDate;
            model.EndDate = endDate;

            return View(model);
        }



        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .FirstOrDefaultAsync(m => m.ID_Booking == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Booking,ID_Client,CheckinDate,CheckoutDate,BookingDate,BookingCode,TotalPersonsNumber,PaymentStatus,Breakfast")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Booking,ID_Client,CheckinDate,CheckoutDate,BookingDate,BookingCode,TotalPersonsNumber,PaymentStatus,Breakfast")] Booking booking)
        {
            if (id != booking.ID_Booking)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.ID_Booking))
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
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .FirstOrDefaultAsync(m => m.ID_Booking == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Booking.FindAsync(id);
            if (booking != null)
            {
                _context.Booking.Remove(booking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.ID_Booking == id);
        }
    }
}
