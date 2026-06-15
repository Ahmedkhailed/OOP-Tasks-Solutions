using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task_6_Hotel_Reservation_System.Room;

namespace Task_6_Hotel_Reservation_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create hotel
            Hotel hotel = new Hotel("Grand Plaza Hotel", "123 Main Street, City");

            // Add rooms
            hotel.addRoom(new Room("101", RoomType.Single, 1, 89.99m, 1));
            hotel.addRoom(new Room("201", RoomType.Double, 2, 129.99m, 2));
            hotel.addRoom(new Room("301", RoomType.Suite, 3, 249.99m, 4));
            hotel.addRoom(new Room("401", RoomType.Deluxe, 4, 349.99m, 3));

            // Add services
            hotel.addService(new Service("S001", "Room Service", 25.00m, "24-hour room service"));
            hotel.addService(new Service("S002", "Spa Treatment", 100.00m, "90-minute massage"));
            hotel.addService(new Service("S003", "Airport Shuttle", 50.00m, "Round trip airport transfer"));
            hotel.addService(new Service("S004", "Breakfast Buffet", 20.00m, "Continental breakfast"));

            // Register guests
            Guest guest1 = new Guest("G001", "Alice Johnson", "alice@email.com",
                   "555-0123", "ID123456", 250);
            Guest guest2 = new Guest("G002", "Bob Smith", "bob@email.com",
                               "555-0456", "ID789012", 100);

            hotel.registerGuest(guest1);
            hotel.registerGuest(guest2);

            // Check available rooms
            DateTime checkIn = DateTime.Now.AddDays(7);
            DateTime checkOut = checkIn.AddDays(3);

            List<Room> availableRooms = hotel.getAvailableRooms(checkIn, checkOut);
            Console.WriteLine("Available rooms for " + checkIn + " to " + checkOut + ":");
            foreach (var room in availableRooms)
            {
                Console.WriteLine("- Room " + room.roomNumber + " (" + room.type + ") - $" + room.pricePerNight + "/night");
            }

            // Create reservation
            Room selectedRoom = Hotel.findRoomByType(availableRooms, RoomType.Suite);
            Reservation reservation = hotel.createReservation(guest1, selectedRoom, checkIn, checkOut, 2);

            Console.WriteLine("\nReservation created: " + reservation.reservationId);

            // Add services to reservation
            reservation.addService(Hotel.findServiceByName(hotel.services, "Breakfast Buffet"));
            reservation.addService(Hotel.findServiceByName(hotel.services, "Airport Shuttle"));

            // Display reservation details
            Console.WriteLine(reservation.getReservationDetails());

            // Calculate total
            Console.WriteLine("\nReservation Summary:");
            Console.WriteLine("Room Cost (" + reservation.getNumberOfNights() + " nights): $" + reservation.getRoomCost());
            Console.WriteLine("Services Cost: $" + reservation.getServicesCost());
            Console.WriteLine("Guest Discount: " + (guest1.getDiscountRate() * 100) + "%");
            Console.WriteLine("Total: $" + reservation.getTotal());
            ;
            // Check in                                                                                                   
            hotel.checkInGuest(reservation.reservationId);
            Console.WriteLine("\nGuest checked in. Room " + selectedRoom.roomNumber + " status: " + selectedRoom.status);
            ;
            // Hotel status                                                                                               
            hotel.displayHotelStatus();
            ;
            // Check out                                                                                                  
            hotel.checkOutGuest(reservation.reservationId);
            Console.WriteLine("\nGuest checked out. Final bill: $" + reservation.getTotal());

            // Calculate revenue
            decimal revenue = hotel.getRevenue(DateTime.Now, DateTime.Now.AddDays(30));
            Console.WriteLine("\nProjected 30-day revenue: $" + revenue);

        }
    }
}
