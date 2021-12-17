using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateSim.Models.Classes
{
    public class NorGate : Gate
    {

        public NorGate(uint InputAmount, uint OutputAmount)
            : base(InputAmount, OutputAmount)
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

            for (int i = 0; i < outputs.Length; i++)
            {
                outputs[i].Out = areAllOutputsFalse;
            }
        }//--------------------------------------------------------------
    }//########################################################
}
