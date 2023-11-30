using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{
    public class Dice: INotifyPropertyChanged
    {
        public int Value { get; set; }

        public bool IsChosen { get; set; }

        public int Index { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
