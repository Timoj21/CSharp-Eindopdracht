using GalaSoft.MvvmLight.Command;
using Gui.Models;
using Gui.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace Gui.ViewModels
{
    public class GameViewModel : ObserverableObject
    {
        private MainViewModel MainViewModel { get; set; }
        public string battlelogTextBlock { get; set; }
        


        public GameViewModel(MainViewModel mainViewModel)
        {
            this.MainViewModel = mainViewModel;

        }

        public void FreezeBoard()
        {
            
        }

        public void UnFreezeBoard()
        {

        }


    }
}
