using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class EmployeeForUpdate
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Title { get; set; } = null!;

        public DateTime BirthDay { get; set; }

        public DateTime StartedDay { get; set; }

        public int HotelId { get; set; }
    }
}
