using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{

    public class Room
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int FloorNumber { get; set; }

        public StatusRoom Status { get; set; } = StatusRoom.READY;

        public int RoomTypeId { get; set; }

        public int HotelId { get; set; }

    }
}
