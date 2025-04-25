using Domain.Interfaces;
using Domain.Models;
using Infrustructure.Data;

namespace Infrustructure.Repositories
{
    public class GuestRepository : GenericRepository<Guest>, IGuestRepository
    {
        public GuestRepository(AppDbContext context) : base(context)
        {
        }
    }

}
