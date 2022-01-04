using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateSim.Models.Classes
{
    /*
     * Truth Table
     * IN  IN  OUT
     * [0] [0] [1]
     * [1] [0] [1]
     * [1] [1] [0]
     */
    public class NandGate : Gate
    {
        public NandGate(uint InputAmount) :
            base(InputAmount, 1)
        {

        }//-----------------------------------------------------------

        protected override void SetOutputs()
        {
            bool areAllInputsTrue = false;

            for (int i = 0; i < inputs.Length; i++)
            {
                if (!inputs[i].In)
                {
                    areAllInputsTrue = true;
                    break;
                }
            }

            outputs[0].Out = areAllInputsTrue; 
        }//--------------------------------------------------------


    }//#####################################################################################
}
