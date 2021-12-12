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
        Output ValueA = new Output();
        Output ValueB = new Output();

       
        public StartUp()
        {
            InitializeComponent();
            OrGate OR = new OrGate(2, 1, "OR");
            NandGate NAND = new NandGate(2, 1, "NAND");
            AndGate AND = new AndGate(2, 1, "AND");

            OR.Link(ValueA, 0);
            OR.Link(ValueB, 1);

            NAND.Link(ValueA, 0);
            NAND.Link(ValueB, 1);

            AND.Link(OR, 0, 0);
            AND.Link(NAND, 0, 1);

            AND.GetOutputRaw(0).AddActionWhenOutputChange(Update);
        }

        private void Toggle1_Click(object sender, RoutedEventArgs e)
        {
            ValueA.Out = !ValueA.Out;
        }
        private void Toggle2_Click(object sender, RoutedEventArgs e)
        {
            ValueB.Out = !ValueB.Out;
        }
        private void Update(Output @out)
        {
            SolidColorBrush brush = new SolidColorBrush();
            if (@out.Out) brush = new SolidColorBrush(Colors.Green);
            else brush = new SolidColorBrush(Colors.Red);

            Rectangle1.Fill = brush;
        }
    }
}
