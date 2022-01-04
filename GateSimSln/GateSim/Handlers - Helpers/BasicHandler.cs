using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateSim.Handlers___Helpers
{
    public class BasicHandler
    {
        public static T[] InitiateTable<T>(T[] EmptyTable) where T : new()
        {
            for (int i = 0; i < EmptyTable.Length; i++)
            {
                EmptyTable[i] = new T();
            }
            return EmptyTable;
        }//-------------------------------------------
    }//#######################################################
}
