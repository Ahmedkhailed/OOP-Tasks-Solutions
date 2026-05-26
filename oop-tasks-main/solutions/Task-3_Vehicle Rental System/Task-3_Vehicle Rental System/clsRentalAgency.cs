using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_Vehicle_Rental_System
{
     class clsRentalAgency
    {
        public string AgencyName { get; private set; }
        public List<clsVehicle> Vehicles { get; private set; }
        public List<clsCustomer> Customers { get; private set; }
        public List<clsRental> Rentals { get; private set; }

        public clsRentalAgency(string agencyName)
        {
            this.AgencyName = agencyName;
            this.Vehicles = new List<clsVehicle>();
            this.Customers = new List<clsCustomer>();
            this.Rentals = new List<clsRental>();
        }

        public void AddVehicle(clsVehicle vehicle)
        {
            if (vehicle == null)
                return;

            Vehicles.Add(vehicle);
        }

        public void RegisterCustomer(clsCustomer customer)
        {
            if (customer == null)
                return;

            Customers.Add(customer);
        }

        public List<clsVehicle> GetAvailableVehicles() => Vehicles.Where(x => x.Status == clsVehicle.enStatus.Available).ToList();

        public clsRental CreateRental(clsCustomer customer, clsVehicle vehicle, int days, bool isInsurance)
        {
            if (vehicle.Status == clsVehicle.enStatus.InMaintenance)
            {
                Console.WriteLine("Sorry, this vehicle cannot be rented at the moment as it needs maintenance.");
                return null;
            }

            if (vehicle.Status == clsVehicle.enStatus.Rented)
            {
                Console.WriteLine("Sorry, this car is currently unavailable.");
                return null;
            }

            clsRental rental = new clsRental(customer, vehicle, days, isInsurance);
            Rentals.Add(rental);
            return rental;
        }
        public void CompleteRental(string rentalId, int odometer)
        {
            if (Rentals == null)
                return;

            clsRental rental = Rentals.Find(x => x.RentalID == rentalId);

            if (rental != null)
            {
                rental.completeRental(odometer);
                Console.WriteLine($"Vehicle {rental.Vehicle.Year} {rental.Vehicle.Make} {rental.Vehicle.Model} is now available.");
            }
        }

        public List<clsRental> GetActiveRentals() => Rentals.Where(x => x.IsActive).ToList();

        public List<clsRental> getCustomerRentals(string CustomerID) => Rentals.Where(x => x.Customer.CustomerID.Equals(CustomerID)).ToList();

        public void DisplayFleet()
        {
            foreach (var item in Vehicles)
            {
                Console.WriteLine($"{item.VehicleId}: {item.Year} {item.Make} {item.Model} - ${item.DailyRate}\\Day - {item.Status.ToString()}" );
            }
        }

        

    }
}
