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

        public bool Turn { get; set; }

        private FieldOccupation[] Results;

        public List<string> boatPositions { get; set; }

        public Player(string name)
        {
            this.Name = name;
            this.Results = new FieldOccupation[25];

            for(int i = 0; i < this.Results.Length; i++)
            {
                this.Results[i] = FieldOccupation.Free;
            }
        }
    }
}
