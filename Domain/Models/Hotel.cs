using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Hotel
    {
        public Hotel()
        {
            Employees = new List<Employee>();
            Rooms = new List<Room>();
        }
        public int Id { get; set; }
        public string Name { get; set; } 

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }


        public List<Employee> Employees { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
