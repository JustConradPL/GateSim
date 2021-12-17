using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateSim.Models.Classes
{
    public class Gate
    {
        public bool shouldAutoRun { private get; set; }

        protected Input[] inputs;
        protected Output[] outputs;
        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$4

        public Gate(uint InputAmount, uint OutputAmount)
        {
            inputs = new Input[InputAmount];
            outputs = new Output[OutputAmount];
            shouldAutoRun = true;
            for (int i = 0; i < OutputAmount; i++)
            {
                outputs[i] = new Output();
            }
            for (int i = 0; i < InputAmount; i++)
            {
                inputs[i] = new Input();
                inputs[i].AddActionWhenInputChange(Run);
            }

        }//------------------------------------------------------------

        public void SetInput(uint Index, bool Value)
        {
            inputs[Index].In = Value;
        }//------------------------------------------------------------

        public bool GetOutput(uint Index)
        {
            return outputs[Index].Out;
        }//------------------------------------------------------------

        public Output GetOutputRaw(uint Index)
        {
            return outputs[Index];
        }//------------------------------------------------------------

        public bool? GetInput(uint Index)
        {
            return inputs[Index].In;
        }//------------------------------------------------------------

        public Input GetInputRaw(uint Index)
        {
            return inputs[Index];
        }//------------------------------------------------------------


        protected virtual void SetOutputs()
        {
            for (int i = 0; i < outputs.Length; i++)
            {
                outputs[i].Out = true;
            }
        }//------------------------------------------

        private void Run(Input In)
        {
            SetOutputs();
        }//------------------------------------------

        public void Link(Gate Source, uint OutputIndex, uint InputIndex)
        {
            Link newLink = new Link(inputs[InputIndex], Source.GetOutputRaw(OutputIndex));
        }//-------------------------------------------

        public void Link(Output @out, uint InputIndex)
        {
            Link newLink = new Link(inputs[InputIndex], @out);
        }//-------------------------------------------

        public static implicit operator bool(Gate e) => e.outputs[0].Out;
    }//######################################################################################
}
