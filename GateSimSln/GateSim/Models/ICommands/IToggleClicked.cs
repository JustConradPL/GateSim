using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GateSim.Models.ICommands
{
    /// <summary>
    /// Nie dotykać. Będzie do uzycia przy implementacji modelu MVVM
    /// </summary>
    public class IToggleClicked : ICommand
    {
        private event Action onExecute;
        public event Action OnExecute
        {
            add
            {
                bool isNull = onExecute == null;

                onExecute += value;
                if (isNull) CanExecuteChanged(this, new EventArgs());
            }
            remove
            {
                onExecute -= value;
                if(onExecute==null) CanExecuteChanged(this, new EventArgs());
            }
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return onExecute != null;
        }

        public void Execute(object parameter)
        {
            onExecute();
        }
    }
}
