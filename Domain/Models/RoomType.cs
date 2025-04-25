using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RoomType
    {
        public RoomType()
        {
            Rooms = new List<Room>();
        }

        public int Id { get; set; }

        public string TypeName { get; set; }

        public int NumOfBeds { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
