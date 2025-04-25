using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IHotelRepository HotelRepository { get; }
        IGuestRepository GuestRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IRoomRepository RoomRepository { get; }
        IBookingRepository BookingRepository { get; }
        IPaymentRepository PaymentRepository { get; }

        int Save();
    }
}
