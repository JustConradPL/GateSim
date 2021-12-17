using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GateSim.Models.Classes;
using System.Windows.Media;
using System.Windows.Input;

namespace GateSim.Models.Modules
{
    public class ToggleButtonModel
    {
        private Output _output = new Output();
        public ICommand Clicked { get; set; }

        public Output OUTPUT
        {
            get { return _output; }
            set { _output = value; }
        }//--------------------------------------------

        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
        public ToggleButtonModel()
        {
            ICommands.IToggleButtonClicked buttonClicked = new ICommands.IToggleButtonClicked();
            buttonClicked.OnExecute += ChangeOutput;
            Clicked = buttonClicked;
        }//--------------------------------

        private void ChangeOutput()
        {
            OUTPUT.Out = !OUTPUT.Out;
        }

        public static implicit operator bool(ToggleButtonModel e) => e.OUTPUT.Out;

    }//##################################################
}
