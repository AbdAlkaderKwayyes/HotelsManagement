using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Staff/{employeeId}/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BookingsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<Booking>> GetBookings(int employeeId)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(employeeId, true);

            if (employee is null)
                return NotFound();

            var bookings = employee.Bookings;
            return Ok(bookings);
        }


        [AllowAnonymous]
        [HttpGet("{bookingId}", Name = "GetBooking")]
        public ActionResult<Booking> GetBooking(int employeeId, int bookingId, bool withPayments = false)
        {

            var employee = _unitOfWork.EmployeeRepository.GetById(employeeId, true);

            if (employee is null)
                return NotFound();



            var booking = _unitOfWork.BookingRepository.GetById(employeeId, bookingId, withPayments);

            if (booking is null)
                return NotFound();

            return Ok(booking);
        }


        [HttpPost]
        public ActionResult<Booking> CreateBooking(int employeeId, Booking booking)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(employeeId, true);

            if (employee is null)
                return NotFound();


            _unitOfWork.BookingRepository.Add(booking, out bool isSuccessful);

            if (!isSuccessful)
                return BadRequest();


            return CreatedAtRoute("GetBooking", new { employeeId = employee.Id, bookingId = booking.Id, withPayments = true}, booking);
        }


        [HttpPut("{bookingId}")]
        public ActionResult<Booking> UpdateBooking(int employeeId, int bookingId, BookingForUpdate booking)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(employeeId, true);

            if (employee is null)
                return NotFound();

            var existingBooking = employee.Bookings.FirstOrDefault(b => b.Id == bookingId);

            if (existingBooking is null)
                return NotFound();

            existingBooking = _mapper.Map<BookingForUpdate, Booking>(booking, existingBooking);

            _unitOfWork.BookingRepository.Update(existingBooking);

            return NoContent();
        }



        [HttpPatch("{bookingId}")]
        public ActionResult<Booking> PartiallyUpdateBooking(int employeeId, int bookingId, JsonPatchDocument<BookingForUpdate> patchDocument)
        {

            var employee = _unitOfWork.EmployeeRepository.GetById(employeeId, true);

            if (employee is null)
                return NotFound();

            var existingBooking = employee.Bookings.FirstOrDefault(b => b.Id == bookingId);

            if (existingBooking is null)
                return NotFound();

            var bookingToPatch = _mapper.Map<BookingForUpdate>(existingBooking);
            patchDocument.ApplyTo(bookingToPatch);

            if (!ModelState.IsValid)
                return BadRequest();

            existingBooking = _mapper.Map<BookingForUpdate, Booking>(bookingToPatch, existingBooking);

            _unitOfWork.BookingRepository.Update(existingBooking);
            

            return NoContent();
        }


        [HttpDelete("{bookingId}")]
        public IActionResult DeleteBooking(int employeeId, int bookingId)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(employeeId, true);

            if (employee is null)
                return NotFound();

            var booking = employee.Bookings.FirstOrDefault(b => b.Id == bookingId);

            if (booking is null)
                return NotFound();

            _unitOfWork.BookingRepository.Remove(booking);

            return NoContent();
        }


    }
}
