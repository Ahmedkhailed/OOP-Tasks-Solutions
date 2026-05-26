using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_Vehicle_Rental_System
{
     class clsRental
    {
        public string RentalID { get; }
        public clsCustomer Customer { get; private set; }
        public clsVehicle Vehicle { get; private set; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; private set; }
        public int StartMileage { get; private set; }
        public int EndMileage { get; private set; }
        public decimal RatePerExtraMile { get; set; }
        public int FreeMilesPerDay { get; private set; }
        public bool IsInsurance { get; private set; }
        public  bool IsActive { get; private set; }
        public clsRental(clsCustomer customer, clsVehicle vehicle, int days,bool isInsurance)
        {
            Guid guid = Guid.NewGuid();

            this.RentalID = guid.ToString();
            this.Customer = customer;
            this.Vehicle = vehicle;
            vehicle.rent();
            this.StartTime = DateTime.Now;
            this.EndTime = DateTime.Now.AddDays(days);
            this.IsActive = true;
            this.IsInsurance = IsInsurance;
            this.StartMileage = vehicle.Odometer;
            this.EndMileage = vehicle.Odometer;
            this.RatePerExtraMile = ratePerExtraMile();
            this.FreeMilesPerDay = freeMilesPerDay();
        }

        private decimal ratePerExtraMile()
        {
            switch (Vehicle.VehicleType)
            {
                case clsVehicle.enVehicleType.Truck:
                    return Vehicle.DailyRate * .05m;
                case clsVehicle.enVehicleType.Luxury:
                    return Vehicle.DailyRate * .07m;
                case clsVehicle.enVehicleType.SUV:
                    return Vehicle.DailyRate * .06m;
                default:
                    return .4m;
            }
        }
        private int freeMilesPerDay()
        {
            switch (Vehicle.VehicleType)
            {
                case clsVehicle.enVehicleType.Truck:
                    return 100;
                case clsVehicle.enVehicleType.Luxury:
                    return 70;
                case clsVehicle.enVehicleType.SUV:
                    return 90;
                default:
                    return 100;
            }
        }

        public double GetRentalDuration() => (EndTime - StartTime).TotalDays;

        public decimal calculateRentalCost() => Vehicle.calculateRentalCost((decimal)GetRentalDuration()) * (1m - DiscountsMatrix());
        public decimal calculateRentalCostWithOutDiscount() => Vehicle.calculateRentalCost((decimal)GetRentalDuration());

        public decimal LateFees() => (DateTime.Now > EndTime) ? ((decimal)(EndTime - DateTime.Now).Hours / 4) * Vehicle.DailyRate : 0;

        public decimal InsuranceFees() => (IsInsurance) ? calculateRentalCost() * (decimal)0.2 : 0;
        
        private decimal DiscountsMatrix()
        {
            int days = (int)(EndTime - StartTime).TotalDays;
            if (days <= 4)
                return 0;
            else if (days <= 13)
                return .5m;
            else if (days <= 29)
                return .15m;
            else
                return .25m;
        }

        public decimal DiscountsMatrix(int days)
        {
            if (days <= 4)
                return 0;
            else if (days <= 13)
                return .5m;
            else if (days <= 29)
                return .15m;
            else
                return .25m;
        }

        private int totalFreeMile() => (int)(EndTime - StartTime).TotalDays * FreeMilesPerDay;
        public int ExcessDistance()
        {
           int excessDistance = (EndMileage - StartMileage) - totalFreeMile();
            return (excessDistance > 0) ? excessDistance : 0;
        }
        private decimal ExtraMileCost()
        {
            EndMileage = Vehicle.Odometer;
            //this man played for odometer
            if (EndMileage < StartMileage)
                return 3000;

            return ExcessDistance();
        }

        public decimal GetTotalCost() => calculateRentalCost() + LateFees() + InsuranceFees() + ExtraMileCost();
        public decimal GetTotalCostWithOutDiscount() => calculateRentalCostWithOutDiscount() + LateFees() + InsuranceFees() + ExtraMileCost();
        public void completeRental(int odometer)
        {
            Vehicle.returnVehicle(odometer);
            EndMileage = odometer;
            EndTime = DateTime.Now;
            IsActive = false;
        }

        public string GetRentalInfo()
        {
            string info = $"RentalID: {RentalID}\nCustomer Name: {Customer.Name}\nModel Vehicle: {Vehicle.Model}\nStartTime : {StartTime}";

            if (IsActive)
                info += "EndTime : Not yet determined";
            else
                info += $"\nEndTime {EndTime}";

            return info + $"\nIsActive: {IsActive}";
        }

        public string GenerateReceipt()
        {
            return $@"
==================================================
                 RENTAL INVOICE                   
==================================================
Invoice ID:   {Guid.NewGuid().ToString()}
Date/Time:    {DateTime.Now.ToString("dd/mm/yyyy H:m")}
Vehicle:      {Vehicle.Make} {Vehicle.Model}
--------------------------------------------------
Rental Period:  {(EndTime - StartTime).TotalDays}
Base Rental Fee: ${Math.Round(calculateRentalCost(), 2)}

--------------------------------------------------
[ MILEAGE DETAILS ]
Odometer Start:  {StartMileage} km
Odometer End:    {EndMileage} km
Total Driven:    {EndMileage - EndMileage} km
Allowed Distance:{totalFreeMile()} km
Excess Distance: {ExcessDistance()} km
Excess Mileage Fee: ${Math.Round(ExtraMileCost(), 2)}

--------------------------------------------------
Subtotal:        ${Math.Round(GetTotalCostWithOutDiscount(), 2)}
Long-Term Discount ({DiscountsMatrix() * 100}%):
==================================================
TOTAL AMOUNT DUE: ${Math.Round(GetTotalCost(), 2)}
==================================================
      Thank you for your business. Drive safe!     
==================================================
";
        }

    }
}
