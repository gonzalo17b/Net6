using System;
using System.Collections.Generic;
using System.Text;

namespace Vehiculos.Domain
{
    public static class IVehicleExtensions
    {
        public static string GetSpeedWithUnits(this IVehicle vehicle)
        {
            return $"{vehicle.GetSpeed()} km / h";
        }
    }
}
