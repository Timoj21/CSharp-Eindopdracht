using GalaSoft.MvvmLight.Command;
using Gui.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Gui.ViewModels
{
    public class MainViewModel : ObserverableObject
    {

        public ObserverableObject SelectedViewModel { get; set; }

        public MainViewModel()
        {
            SelectedViewModel = new StartViewModel();

        }
    }
}
