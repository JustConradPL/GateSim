using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateSim.Models.Classes
{
    /*
     * Truth Table
     * IN  OUT
     * [0] [1]
     * [1] [0]
     */
    public class NotGate : Gate
    {

        public Input @IN
        {
            get
            {
                return inputs[0];
            }
            set
            {
                inputs[0] = value;
            }
        }

        public Output @OUT
        {
            get
            {
                return outputs[0];
            }
        }
        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
        public NotGate() : base(1, 1)
        {
        }//--------------------------------------

        public void SetInput(bool Value)
        {
            IN.In = Value;
        }//---------------------------------------------------

        public bool GetOutput()
        {
            return OUT.Out;
        }//-------------------------------------------------

        protected override void SetOutputs()
        {
            outputs[0].Out = !inputs[0].In;
        }//-------------------------------------------------
    }//##################################################################3
}
