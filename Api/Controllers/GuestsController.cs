using Microsoft.AspNetCore.Mvc;
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
    [Route("api/[controller]")]
    public class GuestsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

       
        public GuestsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<Guest>> GetGuests()
        {
            var guests = _unitOfWork.GuestRepository.GetAll();
            return Ok(guests);
        }


        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetGuest")]
        public ActionResult<Guest> GetGuest(int id)
        {
            var guest = _unitOfWork.GuestRepository.GetById(id);

            if (guest is null)
            {
                return NotFound();
            }

            return Ok(guest);
        }


        [HttpPost]
        public ActionResult<Guest> CreateGuest(Guest guest)
        {
            _unitOfWork.GuestRepository.Add(guest);

            return CreatedAtRoute("GetGuest", new { id = guest.Id }, guest);
        }


        [HttpPut("{id}")]
        public ActionResult<Guest> UpdateGuest(int id, GuestForUpdate guest)
        {
            var existingGuest = _unitOfWork.GuestRepository.GetById(id);

            if (existingGuest is null)
                return NotFound();

            existingGuest = _mapper.Map<GuestForUpdate, Guest>(guest, existingGuest);
            _unitOfWork.GuestRepository.Update(existingGuest);

            return NoContent();
        }



        [HttpPatch("{id}")]
        public ActionResult<Guest> PartiallyUpdateGuest(int id, JsonPatchDocument<GuestForUpdate> patchDocument)
        {
            var existingGuest = _unitOfWork.GuestRepository.GetById(id);

            if (existingGuest is null)
                return NotFound();

            var guestToPatch = _mapper.Map<GuestForUpdate>(existingGuest);
            patchDocument.ApplyTo(guestToPatch);

            if (!ModelState.IsValid)
                return BadRequest();

            existingGuest = _mapper.Map<GuestForUpdate, Guest>(guestToPatch, existingGuest);

            _unitOfWork.GuestRepository.Update(existingGuest);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteGuest(int id)
        {
            var guest = _unitOfWork.GuestRepository.GetById(id);

            if (guest is null)
                return NotFound();

            _unitOfWork.GuestRepository.Remove(guest);

            return NoContent();
        }
    }
}
