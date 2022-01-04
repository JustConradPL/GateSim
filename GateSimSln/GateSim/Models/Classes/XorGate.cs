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
     * [0] [0] [0]
     * [1] [0] [1]
     * [1] [1] [0]
     */
    public class XorGate : Gate
    {
        public XorGate()
            : base(2, 1)
        {
        }//---------------------------------------------------------


        protected override void SetOutputs()
        {
            bool result = false;

            if (inputs[0].In && !inputs[1].In) result = true;
            else if (inputs[1].In && !inputs[0].In) result = true;

            outputs[0].Out = result;
        }//-----------------------------------------------------
    }//#####################################################################################3
}
