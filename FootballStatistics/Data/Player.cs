using System;
using System.Collections.Generic;

#nullable disable

namespace FootballStatistics.Data
{
    public partial class Player
    {
        public Player()
        {
            Goals = new HashSet<Goal>();
        }

        public int Id { get; set; }
        public int PersonId { get; set; }
        public int TeamId { get; set; }
        public int PlayerNumber { get; set; }

        public virtual Person Person { get; set; }
        public virtual Team Team { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }
    }
}
