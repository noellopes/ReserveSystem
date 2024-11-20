using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

namespace ReserveSystem.Controllers
{
    public class RoomServiceBookingController : Controller
    {
        private readonly ReserveSystemContext _context;

        public RoomServiceBookingController(ReserveSystemContext context)
        {
            _context = context;
        }

        // GET: RoomServiceBooking
        public async Task<IActionResult> Index(string searchString, string sortOrder)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["RoomServiceIdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "roomServiceId_desc" : "";
            ViewData["StaffIdSortParm"] = sortOrder == "StaffId" ? "staffId_desc" : "StaffId";
            ViewData["ClientIdSortParm"] = sortOrder == "ClientId" ? "clientId_desc" : "ClientId";
            ViewData["RoomIdSortParm"] = sortOrder == "RoomId" ? "roomId_desc" : "RoomId";
            ViewData["DateTimeSortParm"] = sortOrder == "DateTime" ? "dateTime_desc" : "DateTime";
            ViewData["StartDateSortParm"] = sortOrder == "StartDate" ? "startDate_desc" : "StartDate";
            ViewData["EndDateSortParm"] = sortOrder == "EndDate" ? "endDate_desc" : "EndDate";
            ViewData["BookedStateSortParm"] = sortOrder == "BookedState" ? "bookedState_desc" : "BookedState";
            ViewData["StaffConfirmationSortParm"] = sortOrder == "StaffConfirmation" ? "staffConfirmation_desc" : "StaffConfirmation";
            ViewData["ClientFeedbackSortParm"] = sortOrder == "ClientFeedback" ? "clientFeedback_desc" : "ClientFeedback";
            ViewData["ValueToPaySortParm"] = sortOrder == "ValueToPay" ? "valueToPay_desc" : "ValueToPay";
            ViewData["PaymentDoneSortParm"] = sortOrder == "PaymentDone" ? "paymentDone_desc" : "PaymentDone";

            var bookings = from b in _context.RoomServiceBooking
                           select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                bookings = bookings.Where(b => b.RoomServiceId.ToString().Contains(searchString)
                                       || b.StaffId.ToString().Contains(searchString)
                                       || b.ClientId.ToString().Contains(searchString)
                                       || b.RoomId.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "roomServiceId_desc":
                    bookings = bookings.OrderByDescending(b => b.RoomServiceId);
                    break;
                case "StaffId":
                    bookings = bookings.OrderBy(b => b.StaffId);
                    break;
                case "staffId_desc":
                    bookings = bookings.OrderByDescending(b => b.StaffId);
                    break;
                case "ClientId":
                    bookings = bookings.OrderBy(b => b.ClientId);
                    break;
                case "clientId_desc":
                    bookings = bookings.OrderByDescending(b => b.ClientId);
                    break;
                case "RoomId":
                    bookings = bookings.OrderBy(b => b.RoomId);
                    break;
                case "roomId_desc":
                    bookings = bookings.OrderByDescending(b => b.RoomId);
                    break;
                case "DateTime":
                    bookings = bookings.OrderBy(b => b.DateTime);
                    break;
                case "dateTime_desc":
                    bookings = bookings.OrderByDescending(b => b.DateTime);
                    break;
                case "StartDate":
                    bookings = bookings.OrderBy(b => b.StartDate);
                    break;
                case "startDate_desc":
                    bookings = bookings.OrderByDescending(b => b.StartDate);
                    break;
                case "EndDate":
                    bookings = bookings.OrderBy(b => b.EndDate);
                    break;
                case "endDate_desc":
                    bookings = bookings.OrderByDescending(b => b.EndDate);
                    break;
                case "BookedState":
                    bookings = bookings.OrderBy(b => b.BookedState);
                    break;
                case "bookedState_desc":
                    bookings = bookings.OrderByDescending(b => b.BookedState);
                    break;
                case "StaffConfirmation":
                    bookings = bookings.OrderBy(b => b.StaffConfirmation);
                    break;
                case "staffConfirmation_desc":
                    bookings = bookings.OrderByDescending(b => b.StaffConfirmation);
                    break;
                case "ClientFeedback":
                    bookings = bookings.OrderBy(b => b.ClientFeedback);
                    break;
                case "clientFeedback_desc":
                    bookings = bookings.OrderByDescending(b => b.ClientFeedback);
                    break;
                case "ValueToPay":
                    bookings = bookings.OrderBy(b => (double)b.ValueToPay);
                    break;
                case "valueToPay_desc":
                    bookings = bookings.OrderByDescending(b => (double)b.ValueToPay);
                    break;
                case "PaymentDone":
                    bookings = bookings.OrderBy(b => b.PaymentDone);
                    break;
                case "paymentDone_desc":
                    bookings = bookings.OrderByDescending(b => b.PaymentDone);
                    break;
                default:
                    bookings = bookings.OrderBy(b => b.RoomServiceId);
                    break;
            }

            return View(await bookings.AsNoTracking().ToListAsync());
        }

        // GET: RoomServiceBooking/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomServiceBooking = await _context.RoomServiceBooking
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomServiceBooking == null)
            {
                return NotFound();
            }

            return View(roomServiceBooking);
        }

        // GET: RoomServiceBooking/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomServiceBooking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoomServiceId,StaffId,ClientId,RoomId,DateTime,StartDate,EndDate,BookedState,StaffConfirmation,ClientFeedback,ValueToPay,PaymentDone")] RoomServiceBooking roomServiceBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomServiceBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomServiceBooking);
        }

        // GET: RoomServiceBooking/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomServiceBooking = await _context.RoomServiceBooking.FindAsync(id);
            if (roomServiceBooking == null)
            {
                return NotFound();
            }
            return View(roomServiceBooking);
        }

        // POST: RoomServiceBooking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoomServiceId,StaffId,ClientId,RoomId,DateTime,StartDate,EndDate,BookedState,StaffConfirmation,ClientFeedback,ValueToPay,PaymentDone")] RoomServiceBooking roomServiceBooking)
        {
            if (id != roomServiceBooking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomServiceBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomServiceBookingExists(roomServiceBooking.Id))
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
            return View(roomServiceBooking);
        }

        // GET: RoomServiceBooking/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomServiceBooking = await _context.RoomServiceBooking
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomServiceBooking == null)
            {
                return NotFound();
            }

            return View(roomServiceBooking);
        }

        // POST: RoomServiceBooking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomServiceBooking = await _context.RoomServiceBooking.FindAsync(id);
            if (roomServiceBooking != null)
            {
                _context.RoomServiceBooking.Remove(roomServiceBooking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomServiceBookingExists(int id)
        {
            return _context.RoomServiceBooking.Any(e => e.Id == id);
        }
    }
}
