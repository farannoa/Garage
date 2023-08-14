using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public string OwnerName{ get; set; }
        public string OwnerPhoneNumber{ get; set; }
        public eStatusOfVehicle Status { get; set; }
        public string ModelName { get; set; }
        public string LicenseNumber { get; set; }
        public Material SourceOfEnergy { get; set; }
        public float CurrentCapacityEnergy { get; set; }
        public Wheel[] Wheels { get; set; }

        public Vehicle(
            string i_OwnerName,
            string i_OwnerPhoneNumber,
            string i_ModelName,
            string i_LicenseNumber,
            Material i_SourceOfEnergy,
            float i_CurrentCapacityEnergy,
            int i_NumberOfWheels,
            Wheel[] i_Wheels)
        {
            OwnerName = i_OwnerName; 
            OwnerPhoneNumber = i_OwnerPhoneNumber;  
            ModelName = i_ModelName;
            LicenseNumber = i_LicenseNumber;
            SourceOfEnergy = i_SourceOfEnergy;
            CurrentCapacityEnergy = i_CurrentCapacityEnergy;
            Status = eStatusOfVehicle.NeedToBeFixed;
            Wheels = i_Wheels;
        }

        public abstract List <string> GetUniqueParams();

        public abstract void SetUniqueParams(List <string> i_StringToSet);

        public enum eStatusOfVehicle
        {
            HasFixed,
            NeedToBeFixed,
            BeenPaid
        }

        public virtual string vehicleDetails()
        {
            StringBuilder vehicleDetails = new StringBuilder();
            vehicleDetails.AppendFormat("The vehicle license plate is {0}\n", LicenseNumber);
            vehicleDetails.AppendFormat("The vehicle model is {0}\n", ModelName);
            vehicleDetails.AppendFormat("The vehicle owner is {0}\n", OwnerName);
            vehicleDetails.AppendFormat("The vehicle state in the garage is {0}\n", Status);
            vehicleDetails.AppendFormat("The vehicle's wheel manufacturer is {0}\n", Wheels[0].ManufactureName);
            for (int i = 0; i < Wheels.Length; i++)
            {
                vehicleDetails.AppendFormat("The vehicle's wheel number {0} current air pressure is {1}\n", i + 1, Wheels[i].CurrentVolume);
            }

            vehicleDetails.AppendFormat("The vehicle's works on {0} and its {1}% full\n", SourceOfEnergy.GetType().Name, SourceOfEnergy.CurrentVolumeRatio() * 100);

            return vehicleDetails.ToString();
        }
    }
}
