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
    /// <summary>
    /// Pracuję nad tym
    /// nie ruszać
    /// Ma służyć jako model dla modelu widoku przycisku.
    /// </summary>
    public class ToggleModel
    {
        private Gate _inOut;
        public ICommand Change { get; set; }
        public Output @OUT
        {
            get
            {
                return _inOut.GetOutputRaw(0);
            }
        }
        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
        public ToggleModel(bool isReadOnly)
        {
            ICommands.IToggleClicked buttonClicked = new ICommands.IToggleClicked();
            buttonClicked.OnExecute += ChangeSignal;
            Change = buttonClicked;
        }//--------------------------------

        private void ChangeSignal()
        {
            SetInput(!OUT.Out);
        }//------------------------------------------------

        private void SetInput(bool value)
        {
            _inOut.SetInput(0, value);
        }//------------------------------------------------

        public static implicit operator bool(ToggleModel e) => e.OUT.Out;
        //---------------------------------------------------

    }//##################################################
}
