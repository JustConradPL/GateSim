using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateSim.Models.Classes
{
    public class Output
    {
        private event Action<Output> outputChanged;

        private bool _output;

        public bool Out
        {
            get { return _output; }
            set
            {
                _output = value;
                if (outputChanged != null) outputChanged(this);
            }
        }

        public void AddActionWhenOutputChange(Action<Output> action)
        {
            outputChanged+=action;
        }
    }//###################################################################
}