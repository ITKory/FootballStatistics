using System;
using System.Collections.Generic;

#nullable disable

namespace FootballStatistics.Data
{
    public partial class Country
    {
        public Country()
        {
            People = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
