using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Employee
    {
        public Employee()
        {
            Bookings = new List<Booking>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime StartedDate { get; set; }

        public int HotelId { get; set; }

        public List<Booking> Bookings { get; set; }
    }

}
