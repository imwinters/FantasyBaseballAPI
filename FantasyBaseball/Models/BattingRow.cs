namespace FantasyBaseball.Models
{
    public class BattingRow
    {
        public string PlayerId { get; set; }
        public int YearId { get; set; }
        public int Stint { get; set; }
        public string TeamId { get; set; } 
        public string LeagueId { get; set; }
        public int GamesPlayed { get; set; }
        public int AtBats { get; set; }
        public int Runs { get; set; }
        public int Hits { get; set; }   
        public int Doubles { get; set; }
        public int Triples { get; set; }    
        public int Homeruns { get; set; }  
        public int RBIs { get; set; }   
        public int StolenBases { get; set; }    
        public int CaughtStealing { get; set; }
        public int Walks { get; set; }
        public int StrikeOuts { get; set; } 
        public int IntentionalWalks { get; set; }   
        public int HitByPitch { get; set; }
        public int SacrficeHit { get; set; }
        public int SacrificeFly { get; set; }
        public int GroundIntoDoublePlay { get; set; }
        public int SeasonPointsTotal { get; set; }
        public float GameAvg { get; set; }

        public void CalculateBattingInfo()
        {

            int total = 0;

            total += (Hits - Doubles - Triples - Homeruns);
            total += (Doubles * 2);
            total += (Triples * 3);
            total += (Homeruns * 4);
            total += Runs;
            total += RBIs;
            total += (StolenBases * 2);
            total -= CaughtStealing;
            total += Walks;
            total -= StrikeOuts;

            GameAvg = (total / GamesPlayed);
            SeasonPointsTotal = total;

            SeasonPointsTotal = total;

        }
    }
}