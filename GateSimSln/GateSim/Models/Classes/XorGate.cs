using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateSim.Models.Classes
{
    public class XorGate : Gate
    {
        public XorGate(uint OutputAmount)
            : base(2, OutputAmount)
        {
        }//---------------------------------------------------------


        protected override void SetOutputs()
        {
            bool result = false;

            if (inputs[0].In && !inputs[1].In) result = true;
            else if (inputs[1].In && !inputs[0].In) result = true;

            for (int i = 0; i < outputs.Length; i++)
            {
                outputs[i].Out = result;
            }
        }//-----------------------------------------------------
    }//#####################################################################################3
}
