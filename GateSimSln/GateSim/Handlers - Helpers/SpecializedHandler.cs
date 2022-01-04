using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GateSim.Models.Classes;

namespace GateSim.Handlers___Helpers
{
    public class SpecializedHandler
    {
        public static void AddEventToInputs(ref Input[] inputs, Action<Input> action)
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i].AddActionWhenInputChange(action);
            }
        }//-------------------------------------
    }
}
