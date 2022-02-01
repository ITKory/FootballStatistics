using FootballStatistics.Data;
using FootballStatistics.Infrastructure.Commands;
using FootballStatistics.Infrastructure.Facades;
using FootballStatistics.Models;
using FootballStatistics.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
 

namespace FootballStatistics.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
       
        DataBaseFacade facade;
        
        public MainWindowViewModel()
        {
          
            facade = new DataBaseFacade();
            _collectionGames = new(facade.GetAllGames());
          
        }
        #region Commands

        #region ExampleCommand
        public static RelayCommand Show => new(_ => {
            MessageBox.Show("Hello!");
        },_=>true);
        #endregion
        #endregion


        #region GetListGames
        private ObservableCollection<Game> _collectionGames;
        public ObservableCollection<Game> GetGames { get => _collectionGames; set => Set(ref _collectionGames, value, "GetGames"); }
       
        #endregion

    
        #region SelectedItem
        private Game _selectedGame;
        public Game Game
        {
            get => _selectedGame; set
            {

                Set(ref _selectedGame, value, "Game");
                _firstTeam = facade.GetPlayersByTeamId(_selectedGame.TeamId1);
                _secondTeam = facade.GetPlayersByTeamId(_selectedGame.TeamId2);
                OnPropertyChanged("GetTeamFirst");
                OnPropertyChanged("GetTeamSecond");

                var names = facade.GetTeamNames(_selectedGame);
                _firstTeamName = names[0];
                _secondTeamName = names[1];
                OnPropertyChanged("GetTeamFirstName");
                OnPropertyChanged("GetTeamSecondName");

            }
        }
        #endregion


        #region GetTeamSecondName
        private string _secondTeamName;
        public string GetTeamSecondName { get => _secondTeamName; set => Set(ref _secondTeamName, value, "GetTeamSecondName"); }

        #endregion

        #region GetTeamFirstName
        private string _firstTeamName;
        public string GetTeamFirstName { get => _firstTeamName; set => Set(ref _firstTeamName, value, "GetTeamFirstName"); }

        #endregion

        #region GetTeamFirstPlayers
        private List<PlayerInfo> _firstTeam;
        public List<PlayerInfo> GetTeamFirst { get => _firstTeam; set => Set(ref _firstTeam, value, "GetTeamFirst"); }

        #endregion

        #region GetTeamSecondPlayers
        private List<PlayerInfo> _secondTeam;
        public List<PlayerInfo> GetTeamSecond { get => _secondTeam; set => Set(ref _secondTeam, value, "GetTeamSecond"); }

        #endregion





    }
}
