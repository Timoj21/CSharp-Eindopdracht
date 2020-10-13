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
    }
}
