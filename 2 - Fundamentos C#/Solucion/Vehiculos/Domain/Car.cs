using System;
using System.Collections.Generic;
using System.Text;

namespace Vehiculos.Domain
{
    public class Car : IVehicle
    {
        public int Speed { get; set; }

        public Car(int speed)
        {
            Speed = speed;
        }

        public void SpeedUp()
        {
            Speed += 20;
        }

        public void Brake()
        {
            var speedTotal = Speed - 20;
            if (speedTotal >= 0)
            {
                Speed = speedTotal;
            }
            else
            {
                throw new Exception("No se puede frenar");
            }
        }

        public int GetSpeed()
        {
            return Speed;
        }
    }
}
