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
    public class Gate
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

        //GetOutput zwróci jedynie wartość wyjścia. GetOutputRaw zwróci klasę Output we wskazanym indeksie.

        public bool GetOutput(uint Index)
        {
            return outputs[Index].Out;
        }//------------------------------------------------------------

        public Output GetOutputRaw(uint Index)
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

        protected virtual void SetOutputs()
        {

        }//------------------------------------------

        public void Run()
        {
            SetOutputs();
        }//------------------------------------------

        private void Run(Input In)
        {
            SetOutputs();
        }//------------------------------------------

        //Metody Link są metodami pozwalającymi na podłączenie wejścia bramki do wyjścia innej bramki.
        //Można porównać to do podłączania kabelków.

        public void Link(Gate Source, uint OutputIndex, uint InputIndex)
        {
            Link newLink = new Link(inputs[InputIndex], Source.GetOutputRaw(OutputIndex));
        }//-------------------------------------------

        public void Link(Output @out, uint InputIndex)
        {
            Link newLink = new Link(inputs[InputIndex], @out);
        }//-------------------------------------------

        //Przeważnie proste bramki będą miały nie więcej niż 1 wyjście dlatego konwersja Gate na bool zwróci pierwsze wyjście
        public static implicit operator bool(Gate e) => e.outputs[0].Out;
        //-------------------------------------------
    }//######################################################################################
}
