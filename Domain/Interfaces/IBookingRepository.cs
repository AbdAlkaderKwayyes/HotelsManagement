using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBookingRepository: IGenericRepository<Booking>
    {
        Booking? GetById(int employeeId, int bookingId, bool withPayments);
        void Add(Booking booking, out bool isSuccessful);
    }
}
