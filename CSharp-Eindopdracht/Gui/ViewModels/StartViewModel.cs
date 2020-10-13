using GalaSoft.MvvmLight.Command;
using Gui.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Gui.ViewModels
{
    public class StartViewModel : ObserverableObject
    {
        private MainViewModel MainViewModel{ get; set;}
        public ICommand joinGameCommand { get; set; }

        public ICommand hostGameCommand { get; set; }

        public string Name { get; set; }
   

        public StartViewModel(MainViewModel mainViewModel)
        {

            this.MainViewModel = mainViewModel;  
            joinGameCommand = new RelayCommand(() =>
            {
                if (Name != null && Name.Length > 0)
                {
                    MainViewModel.SelectedViewModel = new GameViewModel(this.MainViewModel);
                    MainViewModel.players.Add(new Models.Player(Name));
                }
            });

            hostGameCommand = new RelayCommand(() =>
            {
                if (Name != null && Name.Length > 0)
                {
                    MainViewModel.SelectedViewModel = new GameViewModel(this.MainViewModel);
                    MainViewModel.players.Add(new Models.Player(Name));
                }
            });
        }


    }
}
