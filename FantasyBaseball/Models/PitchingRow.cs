using System;
namespace FantasyBaseball.Models
{
    public class PitchingRow
    {
        public string PlayerId { get; set; }

        public int YearId { get; set; }

        public int Stint { get; set; }

        public string TeamId { get; set; }

        public string LeagueId { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public int Games { get; set; }

        public int GrandSlam { get; set; }

        public int CompleteGame { get; set; }

        public int Shutout { get; set; }

        public int Saves { get; set; }

        public int OutsPitched { get; set; }

        public int Hits { get; set; }

        public int EarnedRuns { get; set; }

        public int Homeruns { get; set; }

        public int Walks { get; set; }

        public int StrikeOuts { get; set; }

        public int OpponentsBattingAvg { get; set; }

        public int EarnedRunAvg { get; set; }

        public int IntentionalWalks { get; set; }

        public int WildPitches { get; set; }

        public int BattersHit { get; set; }

        public int Balks { get; set; }

        public int BattersFaced { get; set; }

        public int GamesFinished { get; set; }

        public int RunsAllowed { get; set; }

        public int SacrificesHitsByopponent { get; set; }

        public int SacrificeFliesByopponent { get; set; }

        public int GroundIntoDoublePlayByOpponent { get; set; }
        public double GameAvg { get; internal set; }
        public double SeasonPointsTotal { get; internal set; }
    }
}
