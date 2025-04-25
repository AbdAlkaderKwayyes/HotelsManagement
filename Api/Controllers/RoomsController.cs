using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Models;
using Domain.ViewModels;
using Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;


namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Hotels/{hotelId}/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RoomsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<Room>> GetRooms(int hotelId)
        {
            var hotel = _unitOfWork.HotelRepository.GetById(hotelId, withRooms: true);

            if (hotel is null)
                return NotFound();

            var rooms = hotel.Rooms;

            return Ok(rooms);
        }

        [AllowAnonymous]
        [HttpGet("{roomId}", Name = "GetRoom")]
        public ActionResult<Room> GetRoom(int hotelId, int roomId)
        {

            var hotel = _unitOfWork.HotelRepository.GetById(hotelId, withRooms: true);

            if (hotel is null)
                return NotFound();

            var room = hotel.Rooms.FirstOrDefault(r => r.Id == roomId);

            if (room is null)
            {
                return NotFound();
            }

            return Ok(room);
        }


        [HttpPost]
        public ActionResult<Room> CreateRoom(int hotelId, Room room)
        {

            var hotel = _unitOfWork.HotelRepository.GetById(hotelId, withRooms: true);

            if (hotel is null)
                return NotFound();

            _unitOfWork.RoomRepository.Add(room);

            return CreatedAtRoute("GetRoom", new { hotelId = hotelId, RoomId = room.Id }, room);
        }


        [HttpPut("{roomId}")]
        public ActionResult<Room> UpdateRoom(int hotelId, int roomId, RoomForUpdate room)
        {

            var hotel = _unitOfWork.HotelRepository.GetById(hotelId, withRooms: true);

            if (hotel is null)
                return NotFound();


            var existingRoom = hotel.Rooms.FirstOrDefault(r => r.Id == roomId);

            if (existingRoom is null)
                return NotFound();

            existingRoom = _mapper.Map<RoomForUpdate, Room>(room, existingRoom);


            _unitOfWork.RoomRepository.Update(existingRoom);

            return NoContent();
        }



        [HttpPatch("{roomId}")]
        public ActionResult<Room> PartiallyUpdateRoom(int hotelId, int roomId, JsonPatchDocument<RoomForUpdate> patchDocument)
        {
            var hotel = _unitOfWork.HotelRepository.GetById(hotelId, withRooms: true);

            if (hotel is null)
                return NotFound();


            var existingRoom = hotel.Rooms.FirstOrDefault(r => r.Id == roomId);

            if (existingRoom is null)
                return NotFound();


            var roomToPatch = _mapper.Map<RoomForUpdate>(existingRoom);
            patchDocument.ApplyTo(roomToPatch);


            if (!ModelState.IsValid)
                return BadRequest();

            existingRoom = _mapper.Map<RoomForUpdate, Room>(roomToPatch, existingRoom);

            _unitOfWork.RoomRepository.Update(existingRoom);

            return NoContent();
        }



        [HttpDelete("{roomId}")]
        public IActionResult DeleteRoom(int hotelId, int roomId)
        {
            var hotel = _unitOfWork.HotelRepository.GetById(hotelId, withRooms: true);

            if (hotel is null)
                return NotFound();


            var existingRoom = hotel.Rooms.FirstOrDefault(r => r.Id == roomId);

            if (existingRoom is null)
                return NotFound();

            _unitOfWork.RoomRepository.Remove(existingRoom);

            return NoContent();
        }
    }
}
