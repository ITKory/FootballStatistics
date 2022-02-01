using FootballStatistics.Data;
using FootballStatistics.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatistics.Infrastructure.Facades
{
    internal class DataBaseFacade
    {
        private DataBaseModel _context;
        public DataBaseFacade()
        {
            _context = new();

        }
        public List<Game> GetAllGames() => _context.GetAllGames();

        public List<PlayerInfo> GetPlayersByTeamId(int teamId)
             => _context.GetPlayersByTeamId( teamId);
        public List<List<PlayerInfo>> GetPlayersByDate(Game selGame)
            => _context.GetPlayersByDate(selGame.Date);

        public List<string> GetTeamNames(Game selGame)
            => _context.GetTeamNames(selGame);



        //public void GetBestPlayer(Game selGame)
        //{
        //  var players =   _context.GetPlayersByDate(selGame.Date);
        //    PlayerInfo bestPlayer = new PlayerInfo();
         
                

        //}
            
    }
}
