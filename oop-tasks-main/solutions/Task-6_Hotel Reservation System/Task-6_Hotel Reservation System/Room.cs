using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6_Hotel_Reservation_System
{
    internal class Room : IChargeable
    {
        public string roomNumber { get; }
        public enum RoomType { Single, Double, Suite, Deluxe, Presidential }
        public RoomType type { get; private set; } 
        public enum RoomStatus { Available, Occupied , UnderMaintenance , Reserved }
        public RoomStatus status { get; private set; }
        public int floor { get; private set; }
        public decimal pricePerNight { get; private set; }
        public int maxOccupancy { get; private set; }
        public List<string > amenities { get; private set; }

        public Room(string  roomNumber,RoomType type, int floor, decimal pricePerNight, int maxOccupancy)
        {
            this.roomNumber = roomNumber;
            this.type = type;
            this.status = RoomStatus.Available;
            this.floor = floor;
            this.pricePerNight = pricePerNight;
            this.maxOccupancy = maxOccupancy;
            this.amenities = new List<string>();
        }

        public decimal getPrice() => pricePerNight;
        public decimal getPrice(int days) => pricePerNight * days;

        public string getDescription()
        {
            return $"{roomNumber} ({type}) - floor {floor}";
        }

        public bool isAvailable() => status == RoomStatus.Available;

        public void changeStatus(RoomStatus newStatus) => this.status = newStatus;
    }
}
