using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        protected eLicenseType m_LicenseType;
        protected int m_EngineVolume;

        public Motorcycle(string i_OwnerName, string i_OwnerPhoneNumber, string i_ModelName, string i_LicenseNumber, Material i_SourceOfEnergy, float i_CurrentCapacityEnergy, int i_NumberOfWheels, Wheel[] i_Wheels, eLicenseType i_LicenseType, int i_EngineVolume) 
            : base(i_OwnerName, i_OwnerPhoneNumber, i_ModelName, i_LicenseNumber, i_SourceOfEnergy, i_CurrentCapacityEnergy, i_NumberOfWheels, i_Wheels)
        {
            m_LicenseType = i_LicenseType;
            m_EngineVolume = i_EngineVolume;
        }

        private void setLicenseType(string i_LicenseType)
        {
            try
            {
                m_LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_LicenseType);
            }

            catch (FormatException e)
            {
                throw e;
            }
        }

        private void setEngineVolume(string i_EngineVolume)
        {
            try
            {
                m_EngineVolume = (int)Int32.Parse(i_EngineVolume);
            }

            catch (FormatException e)
            {
                throw e;
            }
        }

        public override List <string> GetUniqueParams()
        {
            List <string> listOfUniqueParams = new List<string>
                                                   {
                                                       "License Type",
                                                       "Engine Volume"
                                                   };
            return listOfUniqueParams;
        }

        public override void SetUniqueParams(List <string> i_ListToSet)
        {
            setLicenseType(i_ListToSet[0]);
            setEngineVolume(i_ListToSet[1]);
        }
        public enum eLicenseType
        {
            A,
            A1,
            B1,
            BB,
        }

        public override string vehicleDetails()
        {
            StringBuilder vehicleDetails = new StringBuilder(base.vehicleDetails());
            vehicleDetails.AppendFormat("License Type - {0}\n", m_LicenseType);
            vehicleDetails.AppendFormat("Engine Volume - {0}", m_EngineVolume);

            return vehicleDetails.ToString();
        }
    }
}
