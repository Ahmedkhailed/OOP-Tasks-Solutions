using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_Vehicle_Rental_System
{
     class clsCustomer
    {
        public string CustomerID { get; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string DriverLicenseNumber { get; private set; }

        public clsCustomer(string customerID, string name, string phone, string email, string driverLicenseID)
        {
            this.CustomerID = customerID;
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
            this.DriverLicenseNumber = driverLicenseID;
        }

        public string getCustomerInfo()
        {
            return $"CustomerID : {CustomerID}\nName: {Name}\nPhone: {Phone}\nEmail: {Email}\nDriver license Number: {DriverLicenseNumber}";
        }
    }
}
