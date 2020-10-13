using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Gui.Utils
{
    public class ObserverableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
