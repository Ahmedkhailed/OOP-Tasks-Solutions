using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_6_Hotel_Reservation_System
{
    internal class Hotel
    {
        public string hotelName { get; private set; }
        public string address { get; private set; }
        public List<Room> rooms { get; private set; }
        public List <Reservation> reservations { get; private set; }
        public List<Guest> guests { get; private set; }
        public List<Service> services { get; private set; }
        private static int count = 1;
        
        public Hotel(string hotelName, string address)
        {
            this.hotelName = hotelName;
            this.address = address;
            this.rooms = new List<Room>();
            this.reservations = new List<Reservation>();
            this.guests = new List<Guest>();
            this.services = new List<Service>();
        }

        public void addRoom(Room room)
        {
            if (room == null)
                return;

            rooms.Add(room);
        }

        public void registerGuest(Guest guest)
        {
            if (guest == null) 
                return;

            guests.Add(guest);
        }

        public void addService(Service service)
        {
            if (service == null)
                return;

            services.Add(service);
        }

        private bool isAvailable(Reservation reservation, DateTime checkIn, DateTime checkOut)
        {
            if (reservation.status == Reservation.ReservationStatus.Cancelled)
                return true;

            if (checkIn < reservation.checkOutDate && checkOut > reservation.checkInDate)
                return false;

            return true;
        }

        public List<Room> getAvailableRooms(DateTime checkIn, DateTime checkOut)
        {
            if (rooms == null)
                return null;

            if (reservations == null)
                return rooms;

            List<Room> unAvailableRooms = reservations.FindAll(x => !isAvailable(x, checkIn, checkOut)).Select(x => x.room).ToList();
            unAvailableRooms.RemoveAll(x => x == null);

            return rooms.Except(unAvailableRooms).ToList();
        }

        public List<Room> getAvailableRoomsByType(Room.RoomType type, DateTime checkIn, DateTime checkOut)
        {
            return getAvailableRooms(checkIn, checkOut).FindAll(x => x.type == type);
        }

        public bool isRoomAvailable(Room room, DateTime checkIn, DateTime checkOut)
        {
            return getAvailableRooms(checkIn, checkOut).Any(x => x == room);
        }

        public Reservation createReservation(Guest guest, Room room, DateTime checkIn, DateTime checkOut, int guests)
        {
            if (guest == null || room == null)
                return null;

            if (!isRoomAvailable(room, checkIn, checkOut))
                return null;

            Reservation reservation = new Reservation(++count + guest.guestId, guest, room, checkIn, checkOut, Reservation.ReservationStatus.Confirmed, guests);
            reservations.Add(reservation);

            return reservation;
        }

        public void cancelReservation(string reservationId)
        {
            Reservation reservation = reservations.FirstOrDefault(x => x.reservationId == reservationId);

            if (reservation != null)
                reservation.cancel();
        }

        public void checkInGuest(string reservationId)
        {
            Reservation reservation = reservations.FirstOrDefault(x => x.reservationId == reservationId);

            if (reservation != null)
                reservation.checkIn();
        }
        public void checkOutGuest(string reservationId)
        {
            Reservation reservation = reservations.FirstOrDefault(x => x.reservationId == reservationId);

            if (reservation != null)
                reservation.checkOut();
        }

        public List<Reservation> getReservationsByGuest(string guestId)
        {
            return reservations.FindAll(x => x.guest.guestId == guestId);
        }

        public decimal getCurrentOccupancy()
        {
            if (rooms == null || !rooms.Any())
                return 0;

            return rooms.Average(x => x.status == Room.RoomStatus.Occupied ? 1m : 0m);
        }
        public decimal getCurrentAvailable()
        {
            if (rooms == null || !rooms.Any())
                return 0;

            return rooms.Average(x => x.status == Room.RoomStatus.Available ? 1m : 0m);
        }
        public decimal getCurrentUnderMaintenance()
        {
            if (rooms == null || !rooms.Any())
                return 0;

            return rooms.Average(x => x.status == Room.RoomStatus.UnderMaintenance ? 1m : 0m);
        }

        public decimal getRevenue(DateTime startDate, DateTime endDate)
        {
            return rooms.Sum(x => x.getPrice((int)Math.Ceiling((endDate - startDate).TotalDays)));
        }

        public void displayHotelStatus()
        {
            Console.WriteLine($"\n=== {hotelName} Status ===");
            Console.WriteLine($"Total Rooms: {rooms.Count}");
            Console.WriteLine($"Available: {rooms.Count(x => x.status == Room.RoomStatus.Available)} ({(int)((getCurrentAvailable()) * 100)}%)");
            Console.WriteLine($"Occupied: {rooms.Count(x => x.status == Room.RoomStatus.Occupied)} ({(int)(getCurrentOccupancy() * 100)}%)");
            Console.WriteLine($"Under Maintenance: {rooms.Count(x => x.status == Room.RoomStatus.UnderMaintenance)} ({(int)(getCurrentUnderMaintenance() * 100)}%)");
            Console.WriteLine($"Current Occupancy: {(int)(getCurrentOccupancy() * 100)}%");
        }

        public static Room findRoomByType(List<Room> rooms, Room.RoomType type)
        {
            if (rooms == null)
                return null;

            return rooms.First(x => x.type == type);
        }

        public static Service findServiceByName(List<Service> services, string name)
        {
            return services.First(x => x.name == name);
        }


    }
}
