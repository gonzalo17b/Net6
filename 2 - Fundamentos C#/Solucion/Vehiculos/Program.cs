using System;
using Vehiculos.Domain;

namespace Vehiculos
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            IVehicle vehicle = null;

            do
            {
                Console.WriteLine();
                Console.WriteLine("---------------------");
                Console.WriteLine("Este es el menú. Por favor elija una opción:");
                Console.WriteLine("---------------------");
                Console.WriteLine("Para crear tu vehiculo: Pulsa 1");
                Console.WriteLine("Para acelerar: Pulsa 2");
                Console.WriteLine("Para frenar: Pulsa 3");
                Console.WriteLine("Para ver tu velocidad actual: Pulsa 4");
                Console.WriteLine("Para salir Pulsa 5");

                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        int accountType = 1;
                        Console.WriteLine("De que tipo? 1 Coche. 2 Avión");
                        int.TryParse(Console.ReadLine(), out accountType);
                        switch (accountType)
                        {
                            case 1:
                                vehicle = new Car(0);
                                break;
                            case 2:
                                vehicle = new Plane(0);
                                break;
                        }
                        Console.WriteLine("La cuenta ha sido creada");
                        break;
                    case 2:
                        if (vehicle != null)
                        {
                            vehicle.SpeedUp();
                            Console.WriteLine("Se ha acelerado");
                        }
                        else
                        {
                            Console.WriteLine("No ha creado el vehiculo");
                        }
                        break;
                    case 3:
                        if (vehicle != null)
                        {
                            try
                            {
                                vehicle.Brake();
                                Console.WriteLine("Se ha frenado el vehículo");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("No se puede frenar. Su velocidad ya es 0.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No ha creado el vehículo");
                        }
                        break;
                    case 4:
                        if (vehicle != null)
                        {
                            Console.WriteLine($"Su velocidad actual es de: {vehicle.GetSpeedWithUnits()}");
                        }
                        else
                        {
                            Console.WriteLine("No ha creado el vehículo");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Hasta pronto!");
                        break;
                }
            } while (option != 5);
        }
    }
}
