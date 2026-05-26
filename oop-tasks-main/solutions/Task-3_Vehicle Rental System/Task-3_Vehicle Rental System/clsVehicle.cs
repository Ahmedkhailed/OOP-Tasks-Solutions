using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_Vehicle_Rental_System
{
     class clsVehicle
    {
        public string VehicleId { get; }
        public string Make { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public decimal DailyRate { get; private set; }
        public enum enStatus { Available, Rented, InMaintenance }
        public enStatus Status { get; private set; }
        public enum enVehicleType { SUV, Truck, Luxury };
        public enVehicleType VehicleType { get; private set; }
        public int Odometer { get; private set; }
        public clsVehicle(string vehicleID, string make, string model, int year, decimal dailyRate, enVehicleType vehicleType, int odometer)
        {
            this.VehicleId = vehicleID;
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.DailyRate = dailyRate;
            this.Status = enStatus.Available;
            this.VehicleType = vehicleType;
            this.Odometer = odometer;
        }

        public String GetVehicleInfo()
        {
            return $"vehicleID : {VehicleId}\n"
                + $"Make: {Make}\n"
                + $"Model: {Model}\n"
                + $"Year: {Year}\n"
                + $"DailyRate: {DailyRate}\n"
                + $"Is available: {Status}";
        }

        public void rent() => Status = enStatus.Rented;

        public void returnVehicle(int odometer)
        {
            Odometer = odometer;
            Status = enStatus.Available;
        }

        public void SendVehicleToMaintenance() => Status = enStatus.InMaintenance;

        public decimal calculateRentalCost(decimal days) => days * DailyRate;



    }
}
