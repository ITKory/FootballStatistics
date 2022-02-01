using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatistics.Data
{
    internal class PlayerInfo
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PlayerNumber { get; set; }
        public string GameName { get; set; }
        public string TeamName { get; set; }
        public string Country { get; set; }
    }
}
