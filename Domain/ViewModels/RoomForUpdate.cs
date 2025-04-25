using Domain.Enums;

namespace Domain.ViewModels
{
    public class RoomForUpdate
    {
        public int Number { get; set; }

        public int FloorNumber { get; set; }

        public StatusRoom Status { get; set; }

        public int RoomTyprId { get; set; }

        public int HotelId { get; set; }
    }
}
