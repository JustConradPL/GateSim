using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateSim.Models.Classes
{
    public class Gate
    {
        public enum OutputType
        {
            Nullable = 0,
            NotNullable = 1,
        };
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
                inputs[i].AddActionWhenOutputChange(Run);
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

        public void Run(Input In)
        {
            SetOutputs();
        }//------------------------------------------
    }//######################################################################################
}
