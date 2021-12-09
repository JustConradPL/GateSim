using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateSim.Models.Classes
{
    public class NotGate
    {
        bool input;
        
        public bool Output
        {
            get
            {
                return !input;
            }
        }

        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
        public NotGate(bool InitialValue)
        {
            input = InitialValue;
        }//---------------------------------------------------

        public void SetInput(bool Value)
        {
            input = Value;
        }
    }//##################################################################3
}
