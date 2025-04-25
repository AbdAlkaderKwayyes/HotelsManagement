using Domain.Interfaces;
using Domain.Models;
using Infrustructure.Data;

namespace Infrustructure.Repositories
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(AppDbContext context) : base(context)
        {
        }
    }

}
