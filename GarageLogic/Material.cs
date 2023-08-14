using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Material
    {
        public float CurrentVolume { get; set; }
        protected float m_MaxVolume;

        public abstract void Fill(float i_AddMaterial);

        public float CurrentVolumeRatio()
        {
            return CurrentVolume/ m_MaxVolume;
        }
    }
}
