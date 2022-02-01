using System;
using System.Collections.Generic;

#nullable disable

namespace FootballStatistics.Data
{
    public partial class Person
    {
        public Person()
        {
            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
