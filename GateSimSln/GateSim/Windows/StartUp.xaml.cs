using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using GateSim.Models.Classes;

namespace GateSim
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class StartUp : Window
    {
        public StartUp()
        {
            InitializeComponent();

            AndGate gateA = new AndGate(2, 1);

            NotGate gateB = new NotGate(false);

            gateB.LinkGate(gateA, 0);

            gateA.SetInput(1, false);
            gateA.SetInput(0, true);

            MessageBox.Show(gateB.Output.ToString());

        }
    }
}
