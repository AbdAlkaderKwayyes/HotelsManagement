using Domain.Models;
using Infrustructure.Data;

namespace Infrustructure.Repositories
{
    public class RoomTypeRepository : GenericRepository<RoomType>
    {

        public RoomTypeRepository(AppDbContext context) : base(context)
        {
        }
    }

}
