using Gui.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gui.ViewModels
{
    public class GameViewModel : ObserverableObject
    {
        private MainViewModel MainViewModel { get; set; }

        public GameViewModel(MainViewModel mainViewModel)
        {
            this.MainViewModel = mainViewModel;
        }
    }


}
