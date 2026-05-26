using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_Vehicle_Rental_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create rental agency
            clsRentalAgency agency = new clsRentalAgency("Prime Car Rentals");

            // Add vehicles to fleet
            clsVehicle car1 = new clsVehicle("V001", "Toyota", "Camry", 2022, 45, clsVehicle.enVehicleType.SUV, 1002);
            clsVehicle car2 = new clsVehicle("V002", "Honda", "Accord", 2023, 50, clsVehicle.enVehicleType.Truck, 1203);
            clsVehicle car3 = new clsVehicle("V003", "Tesla", "Model 3", 2023, 85, clsVehicle.enVehicleType.Luxury, 323);

            agency.AddVehicle(car1);
            agency.AddVehicle(car2);
            agency.AddVehicle(car3);

            // Register customers
            clsCustomer customer1 = new clsCustomer("C001", "Alice Johnson", "555-0123",
                        "alice@email.com", "DL123456");
            clsCustomer customer2 = new clsCustomer("C002", "Bob Smith", "555-0456",
                                    "bob@email.com", "DL789012");

            agency.RegisterCustomer(customer1);
            agency.RegisterCustomer(customer2);

            // Display available vehicles
            agency.DisplayFleet();

            // Create rentals
           clsRental rental1 = agency.CreateRental(customer1, car1, 5, true);
            Console.WriteLine("\nRental created: " + rental1.RentalID);
            Console.WriteLine("Total Cost: $" + Math.Round(rental1.GetTotalCost()));

            clsRental rental2 = agency.CreateRental(customer2, car3, 3,false);
            Console.WriteLine("\nRental created: " + rental2.RentalID);
            Console.WriteLine("Total Cost: $" + Math.Round(rental2.GetTotalCost()));

            // Display available vehicles after rentals
            Console.WriteLine("\nAfter rentals:");
            agency.DisplayFleet();

            // Complete a rental
            Console.WriteLine("\nRental " + rental1.RentalID + " completed!");
            agency.CompleteRental(rental1.RentalID, 1300);

            // Display customer rental history
            List<clsRental> customerRentals = agency.getCustomerRentals("C001");
            Console.WriteLine("\nAlice's rental history: " + customerRentals.Count + " rental(s)");

            Console.WriteLine("\n\n" + rental1.GenerateReceipt());

        }
    }
}
