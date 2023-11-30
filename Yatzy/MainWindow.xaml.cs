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

        private Dice[] dices = new Dice[5];
        private PlayerOneScoresheet scoresheet = new PlayerOneScoresheet();

        Random random = new Random();
        int rollDiceCounter = 0;

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
            rollDiceCounter++;
            rollCounter.Content = $"{rollDiceCounter} of 3";

            foreach (var dice in dices)
            {
                if (dice.IsChosen == false)
                {
                    dice.Value = random.Next(1, 7);
                }
            }

            dice0.Content = dices[0].Value;
            dice1.Content = dices[1].Value;
            dice2.Content = dices[2].Value;
            dice3.Content = dices[3].Value;
            dice4.Content = dices[4].Value;

            if (rollDiceCounter == 3)
            {
                rollDiceButton.IsEnabled = false;
                diceContainer.IsEnabled = false;
            }

        }

        private void IsChosen_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && rollDiceCounter > 0)
            {
                int index = int.Parse(button.Name[4..]);
                dices[index].IsChosen = true;
                button.IsEnabled = false;
            }
        }

        private void Ones_Click(object sender, RoutedEventArgs e)
        {
            int points = 0;
            int diceCount = 0;

            foreach (var dice in dices)
            {
                if (dice.Value == 1)
                {
                    diceCount++;
                    points = diceCount * 1;
                }
            }

            MessageBoxResult result = MessageBox.Show($"You have {diceCount} dice(s) with ones ({points} points). Save?", "Ones", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                scoresheet.Ones = points;
                ones.Content = points.ToString();
            }
            else
            {
                return;
            }
        }

        private void Twos_Click(object sender, RoutedEventArgs e)
        {
            int points = 0;
            int diceCount = 0;

            foreach (var dice in dices)
            {
                if (dice.Value == 2)
                {
                    diceCount++;
                    points = diceCount * 2;
                }
            }

            MessageBoxResult result = MessageBox.Show($"You have {diceCount} dice(s) with twos ({points} points). Save?", "Twos", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                scoresheet.Twos = points;
                twos.Content = points.ToString();
            }
            else
            {
                return;
            }
        }

        private void Threes_Click(object sender, RoutedEventArgs e)
        {
            int points = 0;
            int diceCount = 0;

            foreach (var dice in dices)
            {
                if (dice.Value == 3)
                {
                    diceCount++;
                    points = diceCount * 3;
                }
            }

            MessageBoxResult result = MessageBox.Show($"You have {diceCount} dice(s) with threes ({points} points). Save?", "Threes", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                scoresheet.Threes = points;
                threes.Content = points.ToString();
            }
            else
            {
                return;
            }

        }

        private void Fours_Click(object sender, RoutedEventArgs e)
        {
            int points = 0;
            int diceCount = 0;

            foreach (var dice in dices)
            {
                if (dice.Value == 4)
                {
                    diceCount++;
                    points = diceCount * 4;
                }
            }

            MessageBoxResult result = MessageBox.Show($"You have {diceCount} dice(s) with fours ({points} points). Save?", "Fours", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                scoresheet.Fours = points;
                fours.Content = points.ToString();
            }
            else
            {
                return;
            }

        }

        private void Fives_Click(object sender, RoutedEventArgs e)
        {
            int points = 0;
            int diceCount = 0;

            foreach (var dice in dices)
            {
                if (dice.Value == 5)
                {
                    diceCount++;
                    points = diceCount * 5;
                }
            }

            MessageBoxResult result = MessageBox.Show($"You have {diceCount} dice(s) with fives ({points} points). Save?", "Fives", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                scoresheet.Fives = points;
                fives.Content = points.ToString();
            }
            else
            {
                return;
            }
        }

        private void Sixes_Click(object sender, RoutedEventArgs e)
        {
            int points = 0;
            int diceCount = 0;

            foreach (var dice in dices)
            {
                if (dice.Value == 6)
                {
                    diceCount++;
                    points = diceCount * 6;
                }
            }

            MessageBoxResult result = MessageBox.Show($"You have {diceCount} dice(s) with sixes ({points} points). Save?", "Sixes", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                scoresheet.Sixes = points;
                sixes.Content = points.ToString();
            }
            else
            {
                return;
            }
        }

        private void OnePair_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TwoPair_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ThreeOfAKind_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FourOfAKind_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FullHouse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SmallStraight_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LargeStraight_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Yatzy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Chance_Click(object sender, RoutedEventArgs e)
        {
            int points = 0;

            foreach (var dice in dices)
            {
                points += dice.Value;
            }

            MessageBoxResult result = MessageBox.Show($"Total points from all the dices gives you {points} points. Save?", "Chance", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                scoresheet.Chance = points;
                chance.Content = points.ToString();
            }
            else
            {
                return;
            }

        }
    }




}
