using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FootballStatistics.Data;

namespace FootballStatistics.Models
{
    internal class DataBaseModel
    {
        GameContext _context;
        public DataBaseModel()
        {
            _context = new();
            
        }
        public List<Game> GetAllGames() => _context.Games.ToList();
        public List<Team> SelectTeams(Game gameInfo)
              => _context.Teams.Where(t => t.Id == gameInfo.TeamId1 || t.Id == gameInfo.TeamId2).Select(t => t).ToList();
        public List<Player> SelectPlayers(Team teamInfo)
            => _context.Players.Where(t => t.TeamId == teamInfo.Id).Select(p => p).ToList();

        public List<Country> SelectCountries(Team teamInfo)
         => _context.Countries.Where(t => t.Id == teamInfo.CountryId).Select(p => p).ToList();

        public List<Person> SelectPeoples(Player playerInfo)
         => _context.People.Where(t => t.Id == playerInfo.PersonId).Select(p => p).ToList();
    
        public List<string> GetGamesByTeamId(int teamId)
           => _context.Games.Where(t => t.TeamId1 == teamId || t.TeamId1 == teamId).Select(g => g.Name).ToList();

        public List<List<PlayerInfo>> GetPlayersByDate(DateTime date)
        {
            var games = _context.Games.Where(g => g.Date == date).Select(g => g).ToList();
            List<List<PlayerInfo>> listPlayers = new();
            foreach (var game in games)
            {

                listPlayers.Add(_context.Players.Where(t => t.Team.Id == game.TeamId1 || t.Team.Id == game.TeamId2)
                         .Select(x => new PlayerInfo
                         {
                             PlayerId = x.Id,
                             TeamName = x.Team.Name,
                             PlayerNumber = x.PlayerNumber,
                             FirstName = x.Person.FirstName,
                             LastName = x.Person.LastName,
                             Country = x.Person.Country.Name,
                             GameName = game.Name,
                             

                         }).ToList());

            }
            return listPlayers;
        }

        public List<PlayerInfo> GetPlayersByTeamId(int teamId)
        {

            var Players = _context.Players.Where(t => t.Team.Id == teamId)
                       .Select(x => new PlayerInfo
                       {
                           PlayerId = x.Id,
                           TeamName = x.Team.Name,
                           PlayerNumber = x.PlayerNumber,
                           FirstName = x.Person.FirstName,
                           LastName = x.Person.LastName,
                           Country = x.Person.Country.Name,
                          

                       }).ToList();
            return Players;
        }

        public int GetSumGoals(int gameId)
       => _context.Goals.Where(g => g.Game.Id == gameId).Select(x => x.Count).Sum();


        public List<string> GetTeamNames(Game selGame)
            => _context.Teams.Where(g => g.Id == selGame.TeamId1 || g.Id == selGame.TeamId2)
                             .Select(t => t.Name).ToList();


        //public void GetBestPlayerId(DateTime date)
        //{
        //   var score =   _context.Goals.Where(g => g.Game.Date == date).Select(g => g.Count).Max();
        //    var playerId = _context.Goals.Where(g => g.Count == score).Select(p => p.Player.Id);
           
        //}


    }
}
