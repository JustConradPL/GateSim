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

        /***************************
        Wszystko tu jest tymczasowe i zmierzam do tego,
        by nic tu nie było poza niezbędnymi elementami
        ***************************/


        /*
          Obecny kod tworzy tzw. prosty sumator, który w większych ilościach może służyć do dodawania/odejmowania liczb
         */ 
         
        //Te wyjsćia odpowiadają za przyciski w widoku
        Output ValueA = new Output();
        Output ValueB = new Output();
        Output ValueC = new Output();

        public StartUp()
        {
            InitializeComponent();
            //Inicjaja bramek
            OrGate OR = new OrGate(2, 1);
            AndGate AND1 = new AndGate(2, 1);
            AndGate AND2 = new AndGate(2, 1);
            XorGate XOR1 = new XorGate(1);
            XorGate XOR2 = new XorGate(1);

            //Podłączenie bramek
            XOR1.Link(ValueA, 0);
            XOR1.Link(ValueB, 1);

            AND1.Link(ValueA, 0);
            AND1.Link(ValueB, 1);

            AND2.Link(ValueC, 0);
            AND2.Link(XOR1, 0, 1);

            OR.Link(AND1, 0, 0);
            OR.Link(AND2, 0, 1);

            XOR2.Link(XOR1, 0, 0);
            XOR2.Link(ValueC, 1);

            //To nie jest potrzebne do działania bramek ale jest potrzebne (na razie) by w oknie StartUp.xaml cokolwiek się zmieniało

            XOR2.GetOutputRaw(0).AddActionWhenOutputChange(Update);

            OR.GetOutputRaw(0).AddActionWhenOutputChange(Update2);
        }


        //Te wszystkie metody nie mają nic wspólnego z bramkami i są tylko tymczasowe póki nie zrobię modelu MVVM
        private void Toggle1_Click(object sender, RoutedEventArgs e)
        {
            ValueA.Out = !ValueA.Out;
        }
        private void Toggle2_Click(object sender, RoutedEventArgs e)
        {
            ValueB.Out = !ValueB.Out;
        }
        private void Toggle3_Click(object sender, RoutedEventArgs e)
        {
            ValueC.Out = !ValueC.Out;
        }
        private void Update(Output @out)
        {
            SolidColorBrush brush = new SolidColorBrush();
            if (@out.Out) brush = new SolidColorBrush(Colors.Green);
            else brush = new SolidColorBrush(Colors.Red);

            Rectangle1.Fill = brush;
        }
        private void Update2(Output @out)
        {
            SolidColorBrush brush = new SolidColorBrush();
            if (@out.Out) brush = new SolidColorBrush(Colors.Green);
            else brush = new SolidColorBrush(Colors.Red);

            Rectangle2.Fill = brush;
        }
    }
}
