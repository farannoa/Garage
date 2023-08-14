using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Fuel : Material
    {
        public eFuelType FuelType { get; set; }

        public Fuel(float i_CurrentVolume, float i_MaxVolume, eFuelType i_Fuel)
        {
            FuelType = i_Fuel;
            CurrentVolume = i_CurrentVolume;
            m_MaxVolume = i_MaxVolume;

            if (m_MaxVolume < i_CurrentVolume)
            {
                CurrentVolume = m_MaxVolume;
            }
        }

        public override void Fill(float i_AddMaterial)
        {

            if (i_AddMaterial + CurrentVolume <= m_MaxVolume)
            {
                CurrentVolume = i_AddMaterial + CurrentVolume;
            }

            else
            {
                throw new ValueOutOfRangeException(CurrentVolume, m_MaxVolume);
            }
        }

        public enum eFuelType
        {
            Octan96,
            Octan95,
            Octan98,
            Soler,
        }
    }
}
