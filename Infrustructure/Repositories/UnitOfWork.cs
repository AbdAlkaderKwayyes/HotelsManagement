using Domain.Interfaces;
using Infrustructure.Data;

namespace Infrustructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            HotelRepository = new HotelRepository(_context);
            GuestRepository = new GuestRepository(_context);
            EmployeeRepository = new EmployeeRepository(_context);
            RoomRepository = new RoomRepository(_context);
            BookingRepository = new BookingRepository(_context);
            PaymentRepository = new PaymentRepository(_context);
        }


        public IHotelRepository HotelRepository { get; private set; }
        public IGuestRepository GuestRepository { get; private set; }
        public IEmployeeRepository EmployeeRepository { get; private set; }
        public IRoomRepository RoomRepository { get; private set; }
        public IBookingRepository BookingRepository { get; private set; }
        public IPaymentRepository PaymentRepository { get; private set; }


        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
