
using Domain.Interfaces;
using Domain.Models;
using Infrustructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrustructure.Repositories
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(AppDbContext context) : base(context)
        {
        }

        public Hotel? GetById(int id, bool withEmployees = false, bool withRooms = false)
        {
            var query = context.Hotels as IQueryable<Hotel>;

            if(withEmployees)
                query = query.Include(h => h.Employees);

            if (withRooms)
                query = query.Include(h => h.Rooms);

            var hotel = query.FirstOrDefault(h => h.Id == id);

            return hotel;
        }
    }

}
