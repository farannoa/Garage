using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Electric:Material
    {
        public Electric(float i_CurrentVolume, float i_MaxVolume)
        {
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
    }
}
