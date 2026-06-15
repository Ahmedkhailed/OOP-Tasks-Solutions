using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6_Hotel_Reservation_System
{
    internal class Guest
    {

        public string guestId { get; }
        public string name { get; private set; }
        public string email { get; private set; }
        public string phone { get; private set; }
        public string idNumber { get; private set; }
        public int loyaltyPoints { get; private set; }

        public Guest(string guestId, string name, string email, string phone, string idNumber, int loyaltyPoints)
        {
            this.guestId = guestId;
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.idNumber = idNumber;
            this.loyaltyPoints = loyaltyPoints;
        }

        public string getGuestInfo()
        {
            return $"{name} ({guestId})\nEmail: {email}, Phone: {phone}";
        }

        public void addLoyaltyPoints(int points) => loyaltyPoints += points;

        public decimal getDiscountRate() => loyaltyPoints / 5000m;


    }
}
