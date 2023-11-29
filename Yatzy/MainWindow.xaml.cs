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

namespace Yatzy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Dice[] dices = new Dice[4];
        
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < dices.Length; i++)
            {
                dices[i] = new Dice();
            }
        }


        private void RollDice_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();

            dices[0].Value = 1;
            dices[1].Value = 2;
            dices[2].Value = 3;


        }
    }


}
