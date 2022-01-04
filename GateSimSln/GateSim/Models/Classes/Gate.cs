using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateSim.Models.Classes
{
    /// <summary>
    /// Klasa Gate stanowiąca baze dla wszystkich innych bramek
    /// </summary>
    public abstract class Gate
    {
        //Określa czy bramka powinna się sama aktualizować. Wyłączenie może pomóc z optymalizacją
        public bool shouldAutoRun { private get; set; }

        protected Input[] inputs;
        protected Output[] outputs;
        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$4

        public Gate(uint InputAmount, uint OutputAmount)
        {
            inputs = new Input[InputAmount];
            outputs = new Output[OutputAmount];
            shouldAutoRun = true;
            inputs = Handlers___Helpers.BasicHandler.InitiateTable<Input>(inputs);
            outputs = Handlers___Helpers.BasicHandler.InitiateTable<Output>(outputs);
            Handlers___Helpers.SpecializedHandler.AddEventToInputs(ref inputs, Run);
        }//------------------------------------------------------------

        public void SetInput(uint Index, bool Value)
        {
            inputs[Index].In = Value;
        }//------------------------------------------------------------

        //GetOutput zwróci jedynie wartość wyjścia. GetOutputRaw zwróci klasę Output we wskazanym indeksie.

        public bool GetOutput(uint Index = 0)
        {
            return outputs[Index].Out;
        }//------------------------------------------------------------

        public Output GetOutputRaw(uint Index = 0)
        {
            return outputs[Index];
        }//------------------------------------------------------------

        //Ta sama analogia co w GetOutput

        public bool GetInput(uint Index)
        {
            return inputs[Index].In;
        }//------------------------------------------------------------

        public Input GetInputRaw(uint Index)
        {
            return inputs[Index];
        }//------------------------------------------------------------

        //SetOutput i Run nie robią nic w tej klasie jednak w klasach dziedziczonych stanowią zasadę działania bramki
        //metoda SetOutput ma stanowić działanie bramki

        protected abstract void SetOutputs();
        //----------------------------------------------------------

        public void Run()
        {
            SetOutputs();
        }//---------------------------------------------------------

        private void Run(Input In)
        {
            if (shouldAutoRun)
                SetOutputs();
        }//------------------------------------------

        //Metody Link są metodami pozwalającymi na podłączenie wejścia bramki do wyjścia innej bramki.
        //Można porównać to do podłączania kabelków.

        public void Link(Gate Source, uint InputIndex, uint OutputIndex = 0)
        {
            Link newLink = new Link(inputs[InputIndex], Source.GetOutputRaw(OutputIndex), this);
        }//-------------------------------------------

        public void Link(Output @out, uint InputIndex)
        {
            Link newLink = new Link(inputs[InputIndex], @out, this);
        }//-------------------------------------------

        //Przeważnie proste bramki będą miały nie więcej niż 1 wyjście dlatego konwersja Gate na bool zwróci pierwsze wyjście
        public static implicit operator bool(Gate e) => e.outputs[0].Out;
        //-------------------------------------------
    }//######################################################################################
}
