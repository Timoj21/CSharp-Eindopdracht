using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Gui.Models
{
    public class Player : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }

        public List<string> boatPositions { get; set; }

        public Player(string name)
        {
            this.Name = name;
        }
    }
}
