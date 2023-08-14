using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Ex03.GarageLogic
{
    public class GarageManagerLogic
    {
        private static readonly IDictionary<string, Vehicle> sr_CarsInTheGarage = new Dictionary<string, Vehicle>();

        public static IDictionary<string, Vehicle> GetCarsInTheGarage()
        {
            return sr_CarsInTheGarage;
        }

        public static void AddVehicle(string i_TypeOfVehicle, string i_OwnerName, string i_PhoneNumber, string i_ModelName,string i_LicenseNumber, int i_EngineIndex, float i_CurrentVolume, string i_WheelsManufacturer, float i_WheelsCurrentAirPressure)
        {
            Material materialToEnter = null;
            Vehicle vehicleToAdd = null;
            Wheel[] wheels;

            switch (i_TypeOfVehicle)
            {
                case "Car":
                    if(i_EngineIndex == 1)
                    {
                        materialToEnter = new Fuel(i_CurrentVolume, 38, Fuel.eFuelType.Octan95);
                    }
                    else
                    {
                        materialToEnter = new Electric(i_CurrentVolume, 3.3f);
                    }

                    wheels = new Wheel[4];
                    for (int i = 0; i < 4; i++)
                    {
                        wheels[i] = new Wheel(i_WheelsManufacturer, i_WheelsCurrentAirPressure, 29);
                    }

                    vehicleToAdd = new Car(
                        i_OwnerName,
                        i_PhoneNumber,
                        i_ModelName,
                        i_LicenseNumber,
                        materialToEnter,
                        i_CurrentVolume,
                        4,
                        wheels,
                        default,
                        default); 

                    break;
                case "Motorcycle":

                    if (i_EngineIndex == 1)
                    {
                        materialToEnter = new Fuel(i_CurrentVolume, 6.2f, Fuel.eFuelType.Octan98);
                    }

                    else
                    {
                        materialToEnter = new Electric(i_CurrentVolume, 2.5f);
                    }
                    wheels = new Wheel[2];
                    for (int i = 0; i < 2; i++)
                    {
                        wheels[i] = new Wheel(i_WheelsManufacturer, i_WheelsCurrentAirPressure, 31);
                    }
                    vehicleToAdd = new Motorcycle(
                        i_OwnerName,
                        i_PhoneNumber,
                        i_ModelName,
                        i_LicenseNumber,
                        materialToEnter,
                        i_CurrentVolume,
                        2,
                        wheels,
                        default,
                        32);
                    break;

                case "Truck":

                    wheels = new Wheel[16];
                    for (int i = 0; i < 16; i++)
                    {
                        wheels[i] = new Wheel(i_WheelsManufacturer, i_WheelsCurrentAirPressure, 24);
                    }
                    materialToEnter = new Fuel(i_CurrentVolume, 120, Fuel.eFuelType.Soler);
                    vehicleToAdd = new Truck(
                        i_OwnerName,
                        i_PhoneNumber,
                        i_ModelName,
                        i_LicenseNumber,
                        materialToEnter,
                        i_CurrentVolume,
                        16,
                        wheels,
                        false,
                        40);
                    break;

                default:
                    throw new FormatException();
            }

            sr_CarsInTheGarage.Add(i_LicenseNumber, vehicleToAdd);
        }
    }
}
