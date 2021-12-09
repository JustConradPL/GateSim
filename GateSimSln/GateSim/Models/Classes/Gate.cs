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

        protected event Action inputChanged;

        public bool shouldAutoRun { private get; set; }

        protected bool?[] inputs;
        protected bool?[] outputs;
        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$4

        public Gate(uint InputAmount, uint OutputAmount)
        {
            inputs = new bool?[InputAmount];
            outputs = new bool?[OutputAmount];
            shouldAutoRun = true;
            inputChanged += Run;
        }//------------------------------------------------------------

        public void SetInput(uint Index, bool Value)
        {
            inputs[Index] = Value;
            if (shouldAutoRun) inputChanged();
        }//------------------------------------------------------------

        public bool? GetOutput(uint Index, OutputType ExpectedOutput = OutputType.NotNullable)
        {
            return ExpectedOutput == OutputType.Nullable ?
                outputs[Index] : (inputs[Index].HasValue ?
                outputs[Index].Value : throw new NullReferenceException("Expected output is equal to null"));
        }//------------------------------------------------------------

        public bool? GetInput(uint Index, OutputType ExpectedOutput = OutputType.NotNullable)
        {
            return ExpectedOutput == OutputType.Nullable ?
                inputs[Index] : (inputs[Index].HasValue ?
                inputs[Index].Value : throw new NullReferenceException("Expected output is equal to null"));
        }//------------------------------------------------------------


        protected virtual void SetOutputs()
        {
            for (int i = 0; i < outputs.Length; i++)
            {
                outputs[i] = true;
            }
        }//------------------------------------------

        public void Run()
        {
            SetOutputs();
        }
    }//######################################################################################
}
