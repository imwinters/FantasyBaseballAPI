using System;
using System.Collections.Generic;

namespace FantasyBaseball.Models
{
    public class Results
    {
        public DateTime calculatedDate;

        public int LastSeasonWithStatsAvailible { get; set; }

        public List<Player> Pitchers;

        public List<Player> Outfielders { get; set; }

        public List<Player> FirstBase { get; set; }

        public List<Player> SecondBase { get; set; }

        public List<Player> ShortStop { get; set; }

        public List<Player> ThirdBase { get; set; }

        public List<Player> Catcher { get; set; }

        public List<Player> DesignatedHitter { get; set; }

        public Results()
        {
        }
    }
}
