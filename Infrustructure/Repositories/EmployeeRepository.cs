using Domain.Interfaces;
using Domain.Models;
using Infrustructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrustructure.Repositories 
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
           
        }

        public Employee? GetById(int id, bool withBookings)
        {
            var query = context.Employees as IQueryable<Employee>;

            if(withBookings)
                query = query.Include(e => e.Bookings);

            return query.FirstOrDefault(e => e.Id == id);
        }
    }

}
