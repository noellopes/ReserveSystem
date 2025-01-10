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
            var bookings = _context.Booking.AsQueryable();

            // Converter DateOnly para DateTime
            DateTime? beginDateTime = beginDate?.ToDateTime(TimeOnly.MinValue);
            DateTime? endDateTime = endDate?.ToDateTime(TimeOnly.MinValue);

            // Aplicar filtros de data
            if (beginDateTime != null || endDateTime != null)
            {
                if (beginDateTime > endDateTime)
                {
                    return BadRequest("The start date cannot be after the end date.");
                }

                if (beginDateTime != null)
                {
                    bookings = bookings.Where(b => b.CheckinDate >= beginDateTime);
                }

                if (endDateTime != null)
                {
                    bookings = bookings.Where(b => b.CheckoutDate <= endDateTime);
                }
            }

            // Configurar o tamanho da página
            const int pageSize = 10;

            // Preparar o modelo
            var model = new BookingViewModel
            {
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    PageSize = pageSize,
                    TotalItems = await bookings.CountAsync(),
                },
                Bookings = await bookings
                    .OrderBy(b => b.CheckinDate)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(),
                BeginDate = beginDate,
                EndDate = endDate
            };

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

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.ID_Booking == id);
        }
    }
}
