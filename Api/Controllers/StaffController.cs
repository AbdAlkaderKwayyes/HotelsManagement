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
    public class StaffController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StaffController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll();
            return Ok(employees);
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetEmployee")]
        public ActionResult<Employee> GetEmployee(int id, bool withBookings = false)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id, withBookings);

            if (employee == null)
                return NotFound();
            

            return Ok(employee);
        }


        [HttpPost]
        public ActionResult<Employee> CreateEmployee(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Add(employee);

            return CreatedAtRoute("GetEmployee", new { id = employee.Id , withBookings = true}, employee);
        }




        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, EmployeeForUpdate employee)
        {
            var existingEmployee = _unitOfWork.EmployeeRepository.GetById(id);

            if (existingEmployee is null)
                return NotFound();

            existingEmployee = _mapper.Map<EmployeeForUpdate, Employee>(employee, existingEmployee);

            _unitOfWork.EmployeeRepository.Update(existingEmployee);

            return NoContent();
        }


        [HttpPatch("{id}")]
        public ActionResult<Guest> PartiallyUpdateEmployee(int id, JsonPatchDocument<EmployeeForUpdate> patchDocument)
        {

            var existingEmployee = _unitOfWork.EmployeeRepository.GetById(id);

            if (existingEmployee is null)
                return NotFound();

            var employeeToPatch = _mapper.Map<EmployeeForUpdate>(existingEmployee);
            patchDocument.ApplyTo(employeeToPatch);

            if (!ModelState.IsValid)
                return BadRequest();

            existingEmployee = _mapper.Map<EmployeeForUpdate, Employee>(employeeToPatch, existingEmployee);
            _unitOfWork.EmployeeRepository.Update(existingEmployee);

            return NoContent();
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);

            if (employee is null)
                return NotFound();

            _unitOfWork.EmployeeRepository.Remove(employee);

            return NoContent();
        }
    }
}
