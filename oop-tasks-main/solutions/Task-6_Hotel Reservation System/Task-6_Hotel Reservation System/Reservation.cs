using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_6_Hotel_Reservation_System
{
    internal class Reservation
    {

        public string reservationId { get; }
        public Guest guest { get; private set; }
        public Room room { get; private set; }
        public DateTime checkInDate { get; private set; }
        public DateTime checkOutDate { get; private set; }
        public enum ReservationStatus { Pending, Confirmed, CheckedIn, CheckedOut, Cancelled }
        public ReservationStatus status { get; private set; }
        public List<Service> services { get; private set; }
        public int totalGuests { get; private set; }

        public Reservation(string reservationId, Guest guest, Room room, DateTime checkInDate, DateTime checkOutDate, ReservationStatus status, int totalGuests)
        {
            this.reservationId = reservationId;
            this.guest = guest ?? throw new ArgumentNullException(nameof(guest), "This value cannot be passed using a null value.");
            this.room = room ?? throw new ArgumentNullException(nameof(room), "This value cannot be passed using a null value.");
            room.changeStatus(Room.RoomStatus.Occupied);
            this.checkInDate = checkInDate;
            this.checkOutDate = checkOutDate;
            this.status = status;
            this.services = new List<Service>();
            this.totalGuests = totalGuests;
        }

        public int getNumberOfNights() => (int)Math.Ceiling((checkOutDate - checkInDate).TotalDays);

        public decimal getRoomCost() => room.getPrice(getNumberOfNights());

        public decimal getTotal() => (getRoomCost() + getServicesCost()) * (1 - guest.getDiscountRate());

        public void addService(Service service)
        {
            if (service == null)
                return;

            this.services.Add(service);
        }

        public void checkIn()
        {
            status = ReservationStatus.CheckedIn;
            room.changeStatus(Room.RoomStatus.Occupied);
        }

        public void checkOut()
        {
            status = ReservationStatus.CheckedOut;
            room.changeStatus(Room.RoomStatus.Available);
            guest.addLoyaltyPoints((int)getTotal() / 10);
        }

        public void cancel()
        {
            status = ReservationStatus.Cancelled;
            room.changeStatus(Room.RoomStatus.Available);
        }

        public string getReservationDetails()
        {
            string details = "=== Reservation Details ===";
            details += $"\nReservation ID: {reservationId}";
            details += $"\nGuest: {guest.getGuestInfo()}";
            details += $"\nEmail: {guest.email}";
            details += $"\nRoom: {room.getDescription()}";
            details += $"\nCheck-in: {checkInDate.ToString("dd/MM/yyyy")}";
            details += $"\nCheck-out: {checkOutDate.ToString("dd/MM/yyyy")}";
            details += $"\nNights: {getNumberOfNights()}";
            details += $"\nNumber of Guests: {totalGuests}";
            details += $"\nStatus: {status}";

            details += $"\n\nServices:";
            foreach (var item in services)
            {
                details += $"\n- {item.name}: {item.price}";
            }

            return details;
        }

        public decimal getServicesCost()
        {
            if (services == null)
                return 0;

            return services.Sum(x => x.price);
        }
    }
}
