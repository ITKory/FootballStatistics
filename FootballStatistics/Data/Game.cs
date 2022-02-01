using System;
using System.Collections.Generic;

#nullable disable

namespace FootballStatistics.Data
{
    public partial class Game
    {
        public Game()
        {
            Goals = new HashSet<Goal>();
        }

        public int Id { get; set; }
        public int TeamId1 { get; set; }
        public int TeamId2 { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }

        public virtual Team TeamId1Navigation { get; set; }
        public virtual Team TeamId2Navigation { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }
    }
}
