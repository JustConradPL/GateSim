using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateSim.Models.Classes
{
    public class NotGate
    {

        Input input;
        
        public bool Output
        {
            get
            {
                return !input.In;
            }
        }

        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
        public NotGate(bool InitialValue)
        {
            input = new Input();
            input.In = InitialValue;
        }//---------------------------------------------------

        public void SetInput(bool Value)
        {
            input.In = Value;
        }//---------------------------------------------------

        public void LinkGate(Gate Source, uint OutputIndex)
        {
            Source.GetOutputRaw(OutputIndex).AddActionWhenOutputChange(ChangeOutput);
        }//---------------------------------------------------

        private void ChangeOutput(Output output)
        {
            input.In = output.Out;
        }
    }//##################################################################3
}
