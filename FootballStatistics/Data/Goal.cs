using System;
using System.Collections.Generic;

#nullable disable

namespace FootballStatistics.Data
{
    public partial class Goal
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public int Count { get; set; }

        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }
    }
}
