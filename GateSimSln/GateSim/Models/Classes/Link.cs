using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateSim.Models.Classes
{
    public class Link
    {
        public Input IN { get; set; }
        public Output OUT { get; set; }
        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$4

        public Link(Input @in, Output @out)
        {
            IN = @in; OUT = @out;
            LinkToGate();
        }//---------------------------------------
        
        private void LinkToGate()
        {
            OUT.AddActionWhenOutputChange(ChangeInput);
        }//--------------------------------------

        private void ChangeInput(Output @out)
        {
            IN.In = @out.Out;
        }//-------------------------------------------------


    }//#########################################################
}
