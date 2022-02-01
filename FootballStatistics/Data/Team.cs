using System;
using System.Collections.Generic;

#nullable disable

namespace FootballStatistics.Data
{
    public partial class Team
    {
        public Team()
        {
            GameTeamId1Navigations = new HashSet<Game>();
            GameTeamId2Navigations = new HashSet<Game>();
            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Game> GameTeamId1Navigations { get; set; }
        public virtual ICollection<Game> GameTeamId2Navigations { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
