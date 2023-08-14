using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ValueOutOfRangeException : Exception
    {
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
        {
            System.Console.WriteLine("Value out of range exception, {0}, {1}", i_MinValue, i_MaxValue);
        }
    }
}
