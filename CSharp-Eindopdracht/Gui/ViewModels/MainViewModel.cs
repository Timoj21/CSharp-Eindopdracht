using GalaSoft.MvvmLight.Command;
using Gui.Models;
using Gui.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Gui.ViewModels
{
    public class MainViewModel : ObserverableObject
    {
        public ObservableCollection<Player> players { get; set; } = new ObservableCollection<Player>();
        public ObserverableObject SelectedViewModel { get; set; }

        public MainViewModel()
        {
            SelectedViewModel = new StartViewModel(this);
        }
    }
}
