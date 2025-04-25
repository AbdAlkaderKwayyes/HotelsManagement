using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IHotelRepository: IGenericRepository<Hotel>
    {
        Hotel? GetById(int id, bool withEmployees = false, bool withRooms = false);
    }
}
