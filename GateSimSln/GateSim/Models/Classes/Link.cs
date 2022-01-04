using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateSim.Models.Classes
{
    /// <summary>
    /// Połaczenie między wyjściem, a wejściem bramki
    /// Można porównać do kabli
    /// </summary>
    public class Link
    {
        Gate Owner;
        //IN oznacza wejście bramki, które będzie zmieniane w zależności od OUT
        public Input IN { get; set; }
        public Output OUT { get; set; }
        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$4

        public Link(Input @in, Output @out, Gate parent)
        {
            IN = @in; OUT = @out;
            OUT.AddActionWhenOutputChange(ChangeInput);
            Owner = parent;
        }//---------------------------------------

        private void ChangeInput(Output @out)
        {
            IN.In = @out.Out;
        }//-------------------------------------------------


    }//#########################################################
}
