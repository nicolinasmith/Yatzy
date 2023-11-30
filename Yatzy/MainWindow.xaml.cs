using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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

        private ObservableCollection<Dice> dices = new ObservableCollection<Dice>();
        public PlayerOneScoresheet scoresheet = new PlayerOneScoresheet();

        Random random = new Random();
        int rollDiceCounter = 0;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = scoresheet;

            for (int i = 0; i < 5; i++)
            {
                var dice = new Dice();
                dice.Index = i;
                dices.Add(dice);
            }

            diceContainer.ItemsSource = dices;
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

            if (rollDiceCounter == 3)
            {
                rollDiceButton.IsEnabled = false;
                diceContainer.IsEnabled = false;
            }
        }

        private void NewRollDice()
        {
            rollDiceButton.IsEnabled = true;
            diceContainer.IsEnabled = true;
            rollDiceCounter = 0;
            rollCounter.Content = $"{rollDiceCounter} of 3";

            foreach(var dice in dices)
            {
                dice.IsChosen = false;
                dice.Value = 0;
            }
        }

        private void IsChosen_Click(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton toggleButton)
            {
                if (toggleButton.IsChecked == true)
                {
                    int selectedIndex = (int)toggleButton.Tag;
                    dices[selectedIndex].IsChosen = true;
                }
                else
                {

                }
            }
        }

        private void CalculateOnesUppToSixes(int number, string stringNumber, object sender)
        {
            int points = 0;
            int diceCount = 0;

            foreach (var dice in dices)
            {
                if (dice.Value == number)
                {
                    diceCount++;
                    points = diceCount * number;
                }
            }

            MessageBoxResult result = MessageBox.Show($"You have {diceCount} dice(s) with ones ({points} points). Save?", "Yatzy", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                typeof(PlayerOneScoresheet).GetProperty(stringNumber)?.SetValue(scoresheet, points.ToString());
                NewRollDice();
                
                if (sender is Button button)
                {
                    button.IsEnabled = false;
                }
            }
            else
            {
                return;
            }

        }

        private void Ones_Click(object sender, RoutedEventArgs e)
        {
            int number = 1;
            string stringNumber = "Ones";
            CalculateOnesUppToSixes(number, stringNumber, sender);
        }

        private void Twos_Click(object sender, RoutedEventArgs e)
        {
            int number = 2;
            string stringNumber = "Twos";
            CalculateOnesUppToSixes(number, stringNumber, sender);
        }

        private void Threes_Click(object sender, RoutedEventArgs e)
        {
            int number = 3;
            string stringNumber = "Threes";
            CalculateOnesUppToSixes(number, stringNumber, sender);
        }

        private void Fours_Click(object sender, RoutedEventArgs e)
        {
            int number = 4;
            string stringNumber = "Fours";
            CalculateOnesUppToSixes(number, stringNumber, sender);
        }

        private void Fives_Click(object sender, RoutedEventArgs e)
        {
            int number = 5;
            string stringNumber = "Fives";
            CalculateOnesUppToSixes(number, stringNumber, sender);
        }

        private void Sixes_Click(object sender, RoutedEventArgs e)
        {
            int number = 6;
            string stringNumber = "Sixes";
            CalculateOnesUppToSixes(number, stringNumber, sender);
        }

        private void OnePair_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Fixa beräkningen
            int valueOne = 0;
            int valueTwo = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = i + 1; j < 5; j++)
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

            for (int i = 0; i < 5; i++)
            {
                for (int j = i + 1; j < 5; j++)
                {
                    for (int k = j + 1; k < 5; k++)
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
                    //threeOfAKind.IsEnabled = false;
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
                    //threeOfAKind.IsEnabled = false;
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

            for (int i = 0; i < 5; i++)
            {
                for (int j = i + 1; j < 5; j++)
                {
                    for (int k = j + 1; k < 5; k++)
                    {
                        for (int l = k + 1; l < 5; l++)
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
                    //fourOfAKind.IsEnabled = false;
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
                    //fourOfAKind.IsEnabled = false;
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

            for (int i = 0; i < 5; i++)
            {
                diceArray[i] = dices[i].Value;
            }

            bool isSmallStraight = smallStraightArray.OrderBy(x => x).SequenceEqual(diceArray.OrderBy(x => x));

            if (isSmallStraight)
            {
                MessageBoxResult result = MessageBox.Show($"You got a small straight which gives you 15 points. Save?", "Small straight", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    scoresheet.SmallStraight = 15.ToString();
                    //smallStraight.Content = 15.ToString();
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
                    scoresheet.SmallStraight = 0.ToString();
                    //smallStraight.Content = 0.ToString();
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

            for (int i = 0; i < 5; i++)
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
                    //largeStraight.Content = 20.ToString();
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
                scoresheet.Chance = points.ToString();
                //chance.Content = points.ToString();
            }
            else
            {
                return;
            }
        }

        private void CountSubscore_Click(object sender, RoutedEventArgs e)
        {
            if (scoresheet.Ones == null || scoresheet.Twos == null || scoresheet.Threes == null || scoresheet.Fours == null || scoresheet.Fives == null || scoresheet.Sixes == null)
            {
                MessageBox.Show("All options above need to have a value to calculate the subscore.");
                return;
            }

            int subscore = int.Parse(scoresheet.Ones) + int.Parse(scoresheet.Twos) + int.Parse(scoresheet.Threes) + int.Parse(scoresheet.Fours) + int.Parse(scoresheet.Fives) + int.Parse(scoresheet.Sixes);
            scoresheet.Subscore = subscore.ToString();

            if (subscore > 62) 
            { 
                scoresheet.Bonus = 50.ToString();
            }
            else
            {
                scoresheet.Bonus = 0.ToString();
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
