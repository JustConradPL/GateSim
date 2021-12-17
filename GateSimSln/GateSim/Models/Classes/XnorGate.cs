using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateSim.Models.Classes
{
    public class XnorGate : Gate
    {
        public XnorGate(uint OutputAmount)
            : base(2, OutputAmount)
        {
        }//---------------------------------------------------------


        protected override void SetOutputs()
        {
            bool result = true;

            if (inputs[0].In && !inputs[1].In) result = false;
            else if (inputs[1].In && !inputs[0].In) result = false;

            for (int i = 0; i < outputs.Length; i++)
            {
                outputs[i].Out = result;
            }
        }//-----------------------------------------------------
    }//#####################################################################################3
}
