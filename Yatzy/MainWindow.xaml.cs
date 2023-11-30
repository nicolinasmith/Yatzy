using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public PlayerOneScoresheet scoresheet = new PlayerOneScoresheet();

        Random random = new Random();
        int rollDiceCounter = 0;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = scoresheet;

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
                scoresheet.Ones = points.ToString();
                //ones.Content = points.ToString();
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
                scoresheet.Twos = points.ToString();
                //twos.Content = points.ToString();
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
                scoresheet.Threes = points.ToString();
                //threes.Content = points.ToString();
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
                scoresheet.Fours = points.ToString();
                //fours.Content = points.ToString();
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
                scoresheet.Fives = points.ToString();
                //fives.Content = points.ToString();
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
                scoresheet.Sixes = points.ToString();
                //sixes.Content = points.ToString();
            }
            else
            {
                return;
            }
        }

        private void OnePair_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Fixa beräkningen
            int valueOne = 0;
            int valueTwo = 0;

            for (int i = 0; i < dices.Length; i++)
            {
                for (int j = i + 1; j < dices.Length; j++)
                {
                    if (dices[i].Value == dices[j].Value)
                    {
                        valueOne= dices[i].Value;
                        valueTwo= dices[j].Value;
                    }
                }
            }

            MessageBox.Show($"{valueOne} {valueTwo}");

        }

        private void TwoPair_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ThreeOfAKind_Click(object sender, RoutedEventArgs e)
        {
            int diceValue = 0;
            int points = 0;
            bool isThreeOfAKind = false;

            for (int i = 0; i < dices.Length; i++)
            {
                for (int j = i + 1; j < dices.Length; j++)
                {
                    for (int k = j + 1; k < dices.Length; k++)
                    {
                        if (dices[i].Value == dices[j].Value && dices[j].Value == dices[k].Value)
                        {
                            diceValue = dices[i].Value;
                            points = diceValue * 3;
                            isThreeOfAKind = true;
                        }
                    }
                }
            }

            if (isThreeOfAKind)
            {
                MessageBoxResult result = MessageBox.Show($"You have three of a kind ({diceValue}) which gives you {points} points. Save?", "Three of a kind", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    scoresheet.ThreeOfAKind = points.ToString();
                    //threeOfAKind.Content = points.ToString();
                    threeOfAKind.IsEnabled = false;
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show($"You don't have three of a kind. Do you still want to save your score here and recieve 0 points?", "Three of a kind", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    scoresheet.ThreeOfAKind = 0.ToString();
                    //threeOfAKind.Content = 0.ToString();
                    threeOfAKind.IsEnabled = false;
                }
                else
                {
                    return;
                }
            }
        }

        private void FourOfAKind_Click(object sender, RoutedEventArgs e)
        {
            int diceValue = 0;
            int points = 0;
            bool isFourOfAKind = false;

            for (int i = 0; i < dices.Length; i++)
            {
                for (int j = i + 1; j < dices.Length; j++)
                {
                    for (int k = j + 1; k < dices.Length; k++)
                    {
                        for (int l = k + 1; l < dices.Length; l++)
                        {
                            if (dices[i].Value == dices[j].Value && dices[j].Value == dices[k].Value && dices[k].Value == dices[l].Value)
                            {
                                diceValue = dices[i].Value;
                                points = diceValue * 4;
                                isFourOfAKind = true;
                            }
                        }
                    }
                }
            }

            if (isFourOfAKind)
            {
                MessageBoxResult result = MessageBox.Show($"You have four of a kind ({diceValue}) which gives you {points} points. Save?", "Four of a kind", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    scoresheet.FourOfAKind = points.ToString();
                    //fourOfAKind.Content = points.ToString();
                    fourOfAKind.IsEnabled = false;
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show($"You don't have four of a kind. Do you still want to save your score here and receive 0 points?", "Four of a kind", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    scoresheet.FourOfAKind = 0.ToString();
                    //fourOfAKind.Content = 0.ToString();
                    fourOfAKind.IsEnabled = false;
                }
                else
                {
                    return;
                }
            }
        }

        private void FullHouse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SmallStraight_Click(object sender, RoutedEventArgs e)
        {
            int[] smallStraightArray = { 1, 2, 3, 4, 5 };
            int[] diceArray = new int[5];

            for (int i = 0; i < dices.Length; i++)
            {
                diceArray[i] = dices[i].Value;
            }

            bool isSmallStraight = smallStraightArray.OrderBy(x => x).SequenceEqual(diceArray.OrderBy(x => x));

            if (isSmallStraight)
            {
                MessageBoxResult result = MessageBox.Show($"You got a small straight which gives you 15 points. Save?", "Small straight", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    scoresheet.SmallStraight = 15;
                    smallStraight.Content = 15.ToString();
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show($"You don't have a small straight. Do you still want to save your score here and recieve 0 points?", "Small straight", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    scoresheet.SmallStraight = 0;
                    smallStraight.Content = 0.ToString();
                }
                else
                {
                    return;
                }
            }
        }

        private void LargeStraight_Click(object sender, RoutedEventArgs e)
        {
            int[] largeStraightArray = { 2, 3, 4, 5, 6 };
            int[] diceArray = new int[5];

            for (int i = 0; i < dices.Length; i++)
            {
                diceArray[i] = dices[i].Value;
            }

            bool isLargeStraight = largeStraightArray.OrderBy(x => x).SequenceEqual(diceArray.OrderBy(x => x));

            if (isLargeStraight)
            {
                MessageBoxResult result = MessageBox.Show($"You got a large straight which gives you 20 points. Save?", "Large straight", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    scoresheet.LargeStraight = 20.ToString();
                    largeStraight.Content = 20.ToString();
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show($"You don't have a large straight. Do you still want to save your score here and recieve 0 points?", "Large straight", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    scoresheet.LargeStraight = 0.ToString();
                    //largeStraight.Content = 0.ToString();
                }
                else
                {
                    return;
                }
            }

        }

        private void Yatzy_Click(object sender, RoutedEventArgs e)
        {
            int value = dices[0].Value;
            int count = 0;

            foreach (var dice in dices)
            {
                if (dice.Value == value) 
                { 
                    count++;
                }
            }

            if (count == 5)
            {
                MessageBoxResult result = MessageBox.Show($"Congrats, you got yazty which gives you 50 points. Save?", "Yatzy", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    scoresheet.Yatzy = 50.ToString();
                    //yatzy.Content = 50.ToString();
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show($"You don't have yatzy. Do you still want to save your score here and recieve 0 points?", "Yatzy", MessageBoxButton.YesNo, MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    scoresheet.Yatzy = 0.ToString();
                    //yatzy.Content = 0.ToString();
                }
                else
                {
                    return;
                }
            }
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

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            string applicationPath = Process.GetCurrentProcess().MainModule.FileName;
            Process.Start(applicationPath);
            Environment.Exit(0);
        }
    }




}
