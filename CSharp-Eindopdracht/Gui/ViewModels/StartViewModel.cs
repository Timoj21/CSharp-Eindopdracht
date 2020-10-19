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
        private Client client;
        private MainViewModel MainViewModel{ get; set;}
        public ICommand joinGameCommand { get; set; }

        public ICommand hostGameCommand { get; set; }

        public string Name { get; set; }

   

        public StartViewModel(MainViewModel mainViewModel)
        {
            this.client = new Client();
            this.client.OnDataReceived += Client_OnDataReceived;
            this.MainViewModel = mainViewModel;  
            joinGameCommand = new RelayCommand(() =>
            {
                if (Name != null && Name.Length > 0)
                {
                    this.client.SendData("JOINGAME");
                }
            });

            hostGameCommand = new RelayCommand(() =>
            {
                if (Name != null && Name.Length > 0)
                {
                    this.client.SendData("HOSTGAME");
                }
            });
        }

        private void Client_OnDataReceived(string data)
        {
            switch (data)
            {
                case "HOSTSUCCEED":
                    {
                        MainViewModel.SelectedViewModel = new GameViewModel(this.MainViewModel);
                        MainViewModel.players.Add(new Models.Player(Name));
                        break;
                    }
                case "JOINSUCCEED":
                    {
                        MainViewModel.SelectedViewModel = new GameViewModel(this.MainViewModel);
                        MainViewModel.players.Add(new Models.Player(Name));
                        break;
                    }
                case "JOINFAILED":
                    {
                        break;
                    }
            }
        }
    }
}
