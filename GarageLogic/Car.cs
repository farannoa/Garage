using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        protected eColorOfCar m_Color;
        protected eNumberOfDoors m_NumberOfDoors;

        public Car(
            string i_Owner,
            string i_OwnerPhoneNumber,
            string i_ModelName,
            string i_LicenseNumber,
            Material i_SourceOfEnergy,
            float i_CurrentCapacityEnergy,
            int i_NumOfWheels,
            Wheel[] i_Wheels,
            eColorOfCar i_Color,
            eNumberOfDoors i_NumbersOfDoors)
            : base(
                i_Owner,
                i_OwnerPhoneNumber,
                i_ModelName,
                i_LicenseNumber,
                i_SourceOfEnergy,
                i_CurrentCapacityEnergy,
                4,
                i_Wheels)
        {
            m_Color = i_Color;
            m_NumberOfDoors = i_NumbersOfDoors;
        }

        private void setColor(string i_Color)
        {
            try
            {
                m_Color = (eColorOfCar)Enum.Parse(typeof(eColorOfCar), i_Color);
            }

            catch(InvalidCastException e)
            {
                Console.WriteLine("This Color Does Not Exists");
                throw;
            }
        }

        private void setNumberOfDoors(string i_NumberOfDoors)
        {
            try
            {
                m_NumberOfDoors = (eNumberOfDoors)Enum.Parse(typeof(eNumberOfDoors), i_NumberOfDoors);
            }

            catch (InvalidCastException e)
            {
                Console.WriteLine("Please Enter A Valid Numbers Of Doors ");
                throw;
            }
        }

        public override List <string> GetUniqueParams()
        {
            List<string> listOfUniqueParams = new List<string>
                                                 {
                                                     "Color",
                                                     "Number Of Doors"
                                                 };
            return listOfUniqueParams;
        }

        public override void SetUniqueParams( List <string> i_ListToSet)
        {
            setColor(i_ListToSet[0]);
            setNumberOfDoors(i_ListToSet[1]);
        }

        public override string vehicleDetails()
        {
            StringBuilder vehicleDetails = new StringBuilder(base.vehicleDetails());
            vehicleDetails.AppendFormat("Car color - {0}\n", m_Color);
            vehicleDetails.AppendFormat("Number of doors - {0}", m_NumberOfDoors);

            return vehicleDetails.ToString();
        }

        public enum eColorOfCar
        {
            Red,
            White,
            Green,
            Blue,
        }

        public enum eNumberOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
        }
    }
}


