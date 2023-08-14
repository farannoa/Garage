using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel : Material
    {
        public string ManufactureName { get; set; }

        public Wheel(string i_ManufactureName, float i_CurrentAirPressure, float i_MaximalAirPressure)
        {
            ManufactureName = i_ManufactureName;
            CurrentVolume = i_CurrentAirPressure;
            m_MaxVolume = i_MaximalAirPressure;

            if(m_MaxVolume < i_CurrentAirPressure)
            {
                CurrentVolume = m_MaxVolume;
            }
        }

        public override void Fill(float i_AddMaterial)
        {
            if(i_AddMaterial + CurrentVolume <= m_MaxVolume)
            {
                CurrentVolume = i_AddMaterial + CurrentVolume;
            }

            else
            {
                throw new ValueOutOfRangeException(CurrentVolume, m_MaxVolume);
            }
        }

        public void FillToMax()
        {
            CurrentVolume = m_MaxVolume;
        }
    }
}
