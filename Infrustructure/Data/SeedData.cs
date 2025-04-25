using Domain.Models;
using Domain.Enums;

namespace Infrustructure.Data
{
    public static class SeedData
    {
        public static List<Guest> LoadGuests() => new List<Guest>
        {
            new() { Id = 1 ,FirstName = "Alice", LastName = "Williams", BirthDate = new DateTime(1990,02,15), Email = "alice.williams@mail.com", Phone = "555-2233"},

            new() { Id = 2 ,FirstName = "Bob", LastName = "Miller", BirthDate = new DateTime(1985,05,10), Email = "bob.miller@mail.com", Phone = "555-4455"        },

            new() { Id = 3 ,FirstName = "Charlie", LastName = "Davis", BirthDate = new DateTime(1978,09,22), Email = "charlie.davis@mail.com", Phone = "555-6677"  },

            new() { Id = 4 ,FirstName = "Donna", LastName = "Wilson", BirthDate = new DateTime(1988,11,11), Email = "donna.wilson@mail.com", Phone = "555-8899"    },

            new() { Id = 5 ,FirstName = "Edward", LastName = "Moore", BirthDate = new DateTime(1995,03,25), Email = "edward.moore@mail.com", Phone = "555-1122"    },

            new() { Id = 6 ,FirstName = "Fiona", LastName = "Clark", BirthDate = new DateTime(1992-08-30), Email = "fiona.clark@mail.com", Phone = "555-2234"      },

            new() { Id = 7 ,FirstName = "George", LastName = "Hall", BirthDate = new DateTime(1986-07-19), Email = "george.hall@mail.com", Phone = "555-4456"      },

            new() { Id = 8 ,FirstName = "Hannah", LastName = "Lewis", BirthDate = new DateTime(1975-04-10), Email = "hannah.lewis@mail.com", Phone = "555-6678"    },

            new() { Id = 9 ,FirstName = "Ian", LastName = "Walker", BirthDate = new DateTime(1983-11-02), Email = "ian.walker@mail.com", Phone = "555-8890"        },

            new() { Id = 10,FirstName = "Jane", LastName = "Harris", BirthDate = new DateTime(1991-01-17), Email = "jane.harris@mail.com", Phone = "555-1123"      },
        };

        public static List<Hotel> LoadHotels() => new List<Hotel>
        {
            new(){ Id = 1, Name = "Grand Palace Hotel", Email = "info@grandpalace.com", Phone = "555-1234", Address = "123 Palace Road, Cityville"},

            new(){ Id = 2, Name = "Oceanview Resort", Email = "contact@oceanviewresort.com", Phone = "555-5678", Address = "456 Beach Blvd, Seaside Town"},

            new(){ Id = 3, Name = "City Central Inn", Email = "hello@citycentralinn.com", Phone = "555-1122", Address = "101 Center Plaza, Metropolis"},
        };

        public static List<RoomType> LoadRoomTypes() => new List<RoomType>
        {
            new() { Id = 1, TypeName = "Single", NumOfBeds= 1},
            new() { Id = 2, TypeName = "Double", NumOfBeds= 2},
            new() { Id = 3, TypeName = "Family", NumOfBeds= 4},
            new() { Id = 4, TypeName = "Deluxe", NumOfBeds= 3}
        };

        public static List<Employee> LoadEmployees() => new List<Employee>
        {
            new() { Id = 1, FirstName = "John", LastName = "Doe", Title = "Receptionist", Email = "john.doe@grandpalace.com", BirthDate = new DateTime(1980,01,15), StartedDate = new DateTime(2010, 05, 20), HotelId = 1 },

            new() { Id = 2, FirstName = "Jane", LastName = "Smith", Title = "Concierge", Email = "jane.smith@oceanview.com", BirthDate = new DateTime(1992,07,22), StartedDate = new DateTime(2018, 06, 15), HotelId = 1 },

            new() { Id = 3, FirstName = "Emily", LastName = "Johnson", Title = "Receptionist", Email = "emily.johnson@mountain.com", BirthDate = new DateTime(1985, 03, 30), StartedDate = new DateTime(2015, 03, 10), HotelId = 2 },

            new() { Id = 4, FirstName = "Michael", LastName = "Brown", Title = "Concierge", Email = "michael.brown@citycentral.com", BirthDate = new DateTime(1978, 09, 08), StartedDate = new DateTime(2012, 11, 25), HotelId = 2 },

            new() { Id = 5, FirstName = "Sarah", LastName = "Davis", Title = "Receptionist", Email = "sarah.davis@riverside.com", BirthDate = new DateTime(1990, 12, 11), StartedDate = new DateTime(2017, 02, 05), HotelId = 3 },

            new() { Id = 6, FirstName = "Robert", LastName = "Wilson", Title = "Concierge", Email = "robert.wilson@sunset.com", BirthDate = new DateTime(1983, 05, 18), StartedDate = new DateTime(2011, 04, 22), HotelId = 3 },
        };


        public static List<Room> LoadRooms() => new List<Room>
        {
            new() { Id = 1 , Number = 101, FloorNumber = 1, Status = StatusRoom.OCCUPIED    , RoomTypeId = 1, HotelId = 1},
            new() { Id = 2 , Number = 202, FloorNumber = 2, Status = StatusRoom.OCCUPIED    , RoomTypeId = 2, HotelId = 1},
            new() { Id = 3 , Number = 303, FloorNumber = 1, Status = StatusRoom.OCCUPIED    , RoomTypeId = 3, HotelId = 1},
            new() { Id = 4 , Number = 404, FloorNumber = 3, Status = StatusRoom.DIRTY       , RoomTypeId = 4, HotelId = 1},
            new() { Id = 5 , Number = 505, FloorNumber = 2, Status = StatusRoom.OCCUPIED    , RoomTypeId = 2, HotelId = 2},
            new() { Id = 6 , Number = 106, FloorNumber = 1, Status = StatusRoom.OCCUPIED    , RoomTypeId = 3, HotelId = 2},
            new() { Id = 7 , Number = 207, FloorNumber = 2, Status = StatusRoom.DIRTY       , RoomTypeId = 1, HotelId = 2},
            new() { Id = 8 , Number = 308, FloorNumber = 4, Status = StatusRoom.OUT_OF_ORDER, RoomTypeId = 4, HotelId = 2},
            new() { Id = 9 , Number = 409, FloorNumber = 4, Status = StatusRoom.OCCUPIED    , RoomTypeId = 1, HotelId = 3},
            new() { Id = 10, Number = 510, FloorNumber = 1, Status = StatusRoom.READY       , RoomTypeId = 1, HotelId = 3},
            new() { Id = 11, Number = 107, FloorNumber = 3, Status = StatusRoom.READY       , RoomTypeId = 1, HotelId = 3},
            new() { Id = 12, Number = 302, FloorNumber = 3, Status = StatusRoom.READY       , RoomTypeId = 3, HotelId = 3}
        };

        public static List<Booking> LoadBookings() => new List<Booking>
        {
            new() { Id = 1 , CheckinAt = new DateTime(2024, 06, 01), CheckoutAt = new DateTime(2024, 06, 05) , Price = 500 ,  GuestId = 1 , EmployeeId = 1 , RoomId = 1},

            new() { Id = 2 , CheckinAt = new DateTime(2024, 06, 10), CheckoutAt = new DateTime(2024, 06, 15) , Price = 750 ,  GuestId = 2 , EmployeeId = 1 , RoomId = 2},

            new() { Id = 3 , CheckinAt = new DateTime(2024, 06, 20), CheckoutAt = new DateTime(2024, 06, 25) , Price = 600 ,  GuestId = 3 , EmployeeId = 1 , RoomId = 3},

            new() { Id = 4 , CheckinAt = new DateTime(2024, 07, 01), CheckoutAt = new DateTime(2024, 07, 07) , Price = 1000,  GuestId = 4 , EmployeeId = 5 , RoomId = 9},

            new() { Id = 5 , CheckinAt = new DateTime(2024, 07, 10), CheckoutAt = new DateTime(2024, 07, 15) , Price = 900 ,  GuestId = 5 , EmployeeId = 3 , RoomId = 5},

            new() { Id = 6 , CheckinAt = new DateTime(2024, 07, 25), CheckoutAt = new DateTime(2024, 07, 30) , Price = 300 ,  GuestId = 6 , EmployeeId = 3 , RoomId = 6}
        };

        public static List<Payment> LoadPayments() => new List<Payment>
        {
            new() {Id = 1, TotalAmount = 500 , CreatedDate = new DateTime(2024, 06, 01), BookingId = 1, paymentWay = PaymentWay.CreditCard},

            new() {Id = 2, TotalAmount = 500 , CreatedDate = new DateTime(2024, 06, 10), BookingId = 2, paymentWay = PaymentWay.Cash},

            new() {Id = 3, TotalAmount = 600 , CreatedDate = new DateTime(2024, 06, 20), BookingId = 3, paymentWay = PaymentWay.Cash},

            new() {Id = 4, TotalAmount = 600 , CreatedDate = new DateTime(2024, 07, 01), BookingId = 4, paymentWay = PaymentWay.Cash},

            new() {Id = 5, TotalAmount = 200 , CreatedDate = new DateTime(2024, 07, 04), BookingId = 4, paymentWay = PaymentWay.CreditCard},//الزائر رقم 4 قام بالدفع على مرحلتين عن طريق الحجز رقم 4
            
            new() {Id = 6, TotalAmount = 600 , CreatedDate = new DateTime(2024, 07, 10), BookingId = 5, paymentWay = PaymentWay.Cash},

            new() {Id = 7, TotalAmount = 300 , CreatedDate = new DateTime(2024, 07, 14), BookingId = 5, paymentWay = PaymentWay.Cash},//الزائر رقم 5 قام بالدفع على مرحلتين عن طريق الحجز رقم 5
            
            new() {Id = 8, TotalAmount = 300 , CreatedDate = new DateTime(2024, 07, 20), BookingId = 6, paymentWay = PaymentWay.CreditCard},
        };
    }
}
