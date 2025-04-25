using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Booking
    {
        public Booking()
        {
            Payments = new List<Payment>();
        }

        public int Id { get; set; }

        public DateTime CheckinAt { get; set; }

        public DateTime CheckoutAt { get; set; }

        public decimal Price { get; set; }



        public int GuestId { get; set; }

        public int EmployeeId { get; set; }

        public int RoomId { get; set; }

        public List<Payment> Payments { get; set; }

    }

}
