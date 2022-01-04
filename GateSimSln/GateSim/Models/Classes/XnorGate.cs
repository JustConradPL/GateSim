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
     * [1] [1] [1]
     */
    public class XnorGate : Gate
    {
        public XnorGate()
            : base(2, 1)
        {
        }//---------------------------------------------------------


        protected override void SetOutputs()
        {
            bool result = true;

            if (inputs[0].In && !inputs[1].In) result = false;
            else if (inputs[1].In && !inputs[0].In) result = false;

            outputs[0].Out = result;
        }//-----------------------------------------------------
    }//#####################################################################################3
}
