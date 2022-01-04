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
     * [1] [0] [0]
     * [1] [1] [0]
     */
    public class NorGate : Gate
    {

        public NorGate(uint InputAmount)
            : base(InputAmount, 1)
        {
        }//--------------------------------------------------------

        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

        protected override void SetOutputs()
        {
            bool areAllOutputsFalse = true;


            for (int i = 0; i < inputs.Length; i++)
            {
                if (inputs[i].In)
                {
                    areAllOutputsFalse = false;
                    break;
                }
            }

            outputs[0].Out = areAllOutputsFalse;
        }//--------------------------------------------------------------
    }//########################################################
}
