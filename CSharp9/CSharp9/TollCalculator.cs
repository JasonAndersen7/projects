using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommercialRegistration;
using ConsumerVehicleRegistration;
using LiveryRegistration;

namespace CSharp9
{
   public class TollCalculator
    {
        public decimal CalculateToll(object vehicle) =>
            vehicle switch
            {
                Car c           => 2.00m,
                Taxi t          => 3.50m,
                Bus b when ((double)b.Riders / (double)b.Capacity) < 0.50 => 5.00m + 2.00m,
                Bus b when ((double)b.Riders / (double)b.Capacity) > 0.90 => 5.00m - 1.00m,
                Bus b => 5.00m,
                DeliveryTruck t => 10.00m,
                { }             => throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle)),
                null            => throw new ArgumentNullException(nameof(vehicle))
            };
    }
}
