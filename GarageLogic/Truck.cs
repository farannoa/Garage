using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        protected bool m_IsTransportCoolingContent;
        protected int m_TrunkVolume;

        public Truck(string i_Owner, string i_OwnerPhoneNumber, string i_ModelName, string i_LicenseNumber, Material i_SourceOfEnergy, float i_CurrentCapacityEnergy, int i_NumberOfWheels, Wheel[] i_Wheels, bool i_IsTransportCoolingContent, int i_TrunkVolume) 
            : base(i_Owner, i_OwnerPhoneNumber, i_ModelName, i_LicenseNumber, i_SourceOfEnergy, i_CurrentCapacityEnergy, i_NumberOfWheels, i_Wheels)

        {
            m_IsTransportCoolingContent = i_IsTransportCoolingContent;
            m_TrunkVolume = i_TrunkVolume;
        }

        public void SetStatusOfCoolingContent(string i_CoolingContent)
        {
            try
            {
                m_IsTransportCoolingContent = bool.Parse(i_CoolingContent);
            }

            catch (InvalidCastException e)

            {
                    Console.WriteLine("Please Enter true Or false Only In The same Format That Represented");
                    throw e;
            }
        }

        public void SetTrunkVolume(string i_TrunkVolume)
        {
            try
            {
                m_TrunkVolume = int.Parse(i_TrunkVolume);
            }

            catch (InvalidCastException e)
            {
                Console.WriteLine("Please Enter An Integer Only");
                throw;
            }
        }

        public override List<string> GetUniqueParams()
        {
            List<string> listOfUniqueParams = new List<string>
                                                 {
                                                     "Cooling Content",
                                                     "Trunk Volume"
                                                 };
            return listOfUniqueParams;
        }

        public override void SetUniqueParams(List<string> i_ListToSet)
        {
            SetStatusOfCoolingContent(i_ListToSet[0]);
            SetTrunkVolume(i_ListToSet[1]);
        }

        public override string vehicleDetails()
        {
            StringBuilder vehicleDetails = new StringBuilder(base.vehicleDetails());
            vehicleDetails.AppendFormat("Contains cooling cargo - {0}\n", m_IsTransportCoolingContent);
            vehicleDetails.AppendFormat("Trunk Volume - {0}", m_TrunkVolume);

            return vehicleDetails.ToString();
        }
    }
}
