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
        private Output _Out = new Output();
        public Output Out
        {
            get
            {
                return _Out;
            }
        }


        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
        public NotGate(bool InitialValue = false)
        {
            input = new Input();
            input.In = InitialValue;
            input.AddActionWhenInputChange(SetOutput);
        }//---------------------------------------------------

        public void SetInput(bool Value)
        {
            input.In = Value;
        }//---------------------------------------------------

        public bool GetOutput()
        {
            return Out.Out;
        }//-------------------------------------------------

        public void Link(Gate Source, uint OutputIndex)
        {
            Link newLink = new Link(input, Source.GetOutputRaw(OutputIndex));
        }//---------------------------------------------------

        public void Link(Output @out)
        {
            Link newLink = new Link(input, @out);
        }//--------------------------------------------------

        private void SetOutput(Input @in)
        {
            _Out.Out = !@in.In;
        }//-------------------------------------------------
    }//##################################################################3
}
