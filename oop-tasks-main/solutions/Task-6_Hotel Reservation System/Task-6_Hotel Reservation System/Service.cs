using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Task_6_Hotel_Reservation_System
{
    internal class Service : IChargeable
    {

        public string serviceId { get; private set; }
        public string name { get; private set; }
        public decimal price { get; private set; }
        public string description { get; private set; }

        public Service(string serviceId, string name, decimal price, string description)
        {
            this.serviceId = serviceId;
            this.name = name;
            this.price = price;
            this.description = description;
        }

        public string getDescription() => description;

        public decimal getPrice() => price;
    }
}
