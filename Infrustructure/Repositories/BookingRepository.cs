using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;
using Infrustructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrustructure.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(AppDbContext context) : base(context)
        {
        }

        public Booking? GetById(int employeeId, int bookingId, bool withPayments)
        {
            var query = context.Bookings as IQueryable<Booking>;

            if (withPayments)
                query = query.Include(b => b.Payments);



            return query.FirstOrDefault(b => b.Id == bookingId && b.EmployeeId == employeeId);//وضعنا هذا الشرط لأنه في حال أرسل المستخدم معرف للحجز غير موجود ليس لديه نفس معرف الموظف 
        }


        //للتأكد من أن الغرفة في حالة Ready 
        public void Add(Booking booking, out bool isSuccessful)
        {
            var room = context.Rooms.FirstOrDefault(r => r.Id == booking.RoomId);

            if (room is not null && room.Status == StatusRoom.READY)
            {
                room.Status = StatusRoom.OCCUPIED;
                context.Bookings.Add(booking);
                context.SaveChanges();
                isSuccessful = true;
            }
            else
            {
                isSuccessful = false;
            }
        }
    }

}
