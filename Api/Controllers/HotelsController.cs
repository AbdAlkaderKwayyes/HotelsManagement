using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.ViewModels;
using Domain.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HotelsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<Hotel>> GetHotels()    
        {
            var hotels = _unitOfWork.HotelRepository.GetAll();
            return Ok(hotels);
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetHotel")]
        public ActionResult<Hotel> GetHotel(int id, bool withEmployees = false, bool withRooms = false)
        {
            var hotel = _unitOfWork.HotelRepository.GetById(id, withEmployees, withRooms);

            if (hotel is null)
                return NotFound();

            return Ok(hotel);
        }


        [HttpPost]
        public ActionResult<Hotel> CreateHotel(Hotel hotel)
        {
            _unitOfWork.HotelRepository.Add(hotel);

            return CreatedAtRoute("GetHotel", new { id = hotel.Id , withEmployees = false, withRooms = false }, hotel);
        }


        [HttpPut("{id}")]
        public ActionResult<Hotel> UpdateHotel(int id, HotelForUpdate hotel)
        {
            var existingHotel = _unitOfWork.HotelRepository.GetById(id);

            if (existingHotel is null)
                return NotFound();

            existingHotel = _mapper.Map<HotelForUpdate, Hotel>(hotel, existingHotel);

            _unitOfWork.HotelRepository.Update(existingHotel);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult<Hotel> PartiallyUpdateHotel(int id, JsonPatchDocument<HotelForUpdate> patchDocument)
        {

            var existingHotel = _unitOfWork.HotelRepository.GetById(id);

            if (existingHotel is null)
                return NotFound();

            var hotelToPatch = _mapper.Map<HotelForUpdate>(existingHotel);
            patchDocument.ApplyTo(hotelToPatch);

            if (!ModelState.IsValid)
                return BadRequest();

            existingHotel = _mapper.Map<HotelForUpdate, Hotel>(hotelToPatch, existingHotel);

            _unitOfWork.HotelRepository.Update(existingHotel);

            return NoContent();
        }




        [HttpDelete("{id}")]
        public IActionResult DeleteGuest(int id)
        {
            var hotel = _unitOfWork.HotelRepository.GetById(id);

            if (hotel is null)
                return NotFound();

            _unitOfWork.HotelRepository.Remove(hotel);

            return NoContent();
        }

    }
}
