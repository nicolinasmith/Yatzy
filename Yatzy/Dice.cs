using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Yatzy.Enums;

namespace Yatzy
{
    public class Dice: DependencyObject, INotifyPropertyChanged
    {
        public int Value { get; set; }

        public bool IsChosen { get; set; }

        public int Index { get; set; }

        public DiceStatus DiceStatus
        {
            get { return (DiceStatus)GetValue(DiceStatusProperty); }
            set { SetValue(DiceStatusProperty, value); }
        }

        public static readonly DependencyProperty DiceStatusProperty =
            DependencyProperty.Register("DiceStatus", typeof(DiceStatus), typeof(Dice), new PropertyMetadata(DiceStatus.Zero));


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
