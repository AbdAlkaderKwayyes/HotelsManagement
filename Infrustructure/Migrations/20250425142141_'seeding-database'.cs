using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class seedingdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice.williams@mail.com", "Alice", "Williams", "555-2233" },
                    { 2, new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.miller@mail.com", "Bob", "Miller", "555-4455" },
                    { 3, new DateTime(1978, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "charlie.davis@mail.com", "Charlie", "Davis", "555-6677" },
                    { 4, new DateTime(1988, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "donna.wilson@mail.com", "Donna", "Wilson", "555-8899" },
                    { 5, new DateTime(1995, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "edward.moore@mail.com", "Edward", "Moore", "555-1122" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1954), "fiona.clark@mail.com", "Fiona", "Clark", "555-2234" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1960), "george.hall@mail.com", "George", "Hall", "555-4456" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1961), "hannah.lewis@mail.com", "Hannah", "Lewis", "555-6678" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1970), "ian.walker@mail.com", "Ian", "Walker", "555-8890" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1973), "jane.harris@mail.com", "Jane", "Harris", "555-1123" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "123 Palace Road, Cityville", "info@grandpalace.com", "Grand Palace Hotel", "555-1234" },
                    { 2, "456 Beach Blvd, Seaside Town", "contact@oceanviewresort.com", "Oceanview Resort", "555-5678" },
                    { 3, "101 Center Plaza, Metropolis", "hello@citycentralinn.com", "City Central Inn", "555-1122" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "NumOfBeds", "TypeName" },
                values: new object[,]
                {
                    { 1, 1, "Single" },
                    { 2, 2, "Double" },
                    { 3, 4, "Family" },
                    { 4, 3, "Deluxe" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "HotelId", "LastName", "StartedDate", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@grandpalace.com", "John", 1, "Doe", new DateTime(2010, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Receptionist" },
                    { 2, new DateTime(1992, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@oceanview.com", "Jane", 1, "Smith", new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Concierge" },
                    { 3, new DateTime(1985, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.johnson@mountain.com", "Emily", 2, "Johnson", new DateTime(2015, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Receptionist" },
                    { 4, new DateTime(1978, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.brown@citycentral.com", "Michael", 2, "Brown", new DateTime(2012, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Concierge" },
                    { 5, new DateTime(1990, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "sarah.davis@riverside.com", "Sarah", 3, "Davis", new DateTime(2017, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Receptionist" },
                    { 6, new DateTime(1983, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "robert.wilson@sunset.com", "Robert", 3, "Wilson", new DateTime(2011, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Concierge" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "FloorNumber", "HotelId", "Number", "RoomTypeId", "Status" },
                values: new object[,]
                {
                    { 1, 1, 1, 101, 1, 0 },
                    { 2, 2, 1, 202, 2, 0 },
                    { 3, 1, 1, 303, 3, 0 },
                    { 4, 3, 1, 404, 4, 1 },
                    { 5, 2, 2, 505, 2, 0 },
                    { 6, 1, 2, 106, 3, 0 },
                    { 7, 2, 2, 207, 1, 1 },
                    { 8, 4, 2, 308, 4, 3 },
                    { 9, 4, 3, 409, 1, 0 },
                    { 10, 1, 3, 510, 1, 2 },
                    { 11, 3, 3, 107, 1, 2 },
                    { 12, 3, 3, 302, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CheckinAt", "CheckoutAt", "EmployeeId", "GuestId", "Price", "RoomId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 500m, 1 },
                    { 2, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 750m, 2 },
                    { 3, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 600m, 3 },
                    { 4, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4, 1000m, 9 },
                    { 5, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, 900m, 5 },
                    { 6, new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 6, 300m, 6 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "BookingId", "CreatedDate", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m },
                    { 2, 2, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m },
                    { 3, 3, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 600m },
                    { 4, 4, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 600m },
                    { 5, 4, new DateTime(2024, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 200m },
                    { 6, 5, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 600m },
                    { 7, 5, new DateTime(2024, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 300m },
                    { 8, 6, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 300m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
