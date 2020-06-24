using System;
using System.Collections.Generic;

namespace FantasyBaseball.Models
{
    public class Results
    {
        public DateTime calculatedDate;

        public int LastSeasonWithStatsAvailible { get; set; }

        public IEnumerable<Player> Pitchers;

        public IEnumerable<Player> Outfielders { get; set; }

        public IEnumerable<Player> FirstBase { get; set; }

        public IEnumerable<Player> SecondBase { get; set; }

        public IEnumerable<Player> ShortStop { get; set; }

        public IEnumerable<Player> ThirdBase { get; set; }

        public IEnumerable<Player> Catcher { get; set; }

        public IEnumerable<Player> DesignatedHitter { get; set; }

        public Results()
        {
        }
    }
}
