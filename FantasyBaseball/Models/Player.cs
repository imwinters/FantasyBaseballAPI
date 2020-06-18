using System.Collections.Generic;
using FantasyBaseball.Extensions;

namespace FantasyBaseball.Models
{
    public class Player
    {
        private int _Id;
        private string _Name;
        private string _Position;
        private List<BattingRow> BattingHistory;
        private List<PitchingRow> PitchingHistory;
        private double AvgScoreBySeason;
        private double ScoreVarianceBySeason;
        private double ScoreStandardDeviationBySeason;

        public Player(int Id, string Name, string Position)
        {
            _Id = Id;
            _Name =Name;
            _Position = Position;

        }

        public string GetPlayerInfo()
        {
            return string.Concat(_Id.ToString(), _Name, _Position);
        }

        public override string ToString()
        {
            return $"Id: {_Id}," +
                $" Name: {_Name}, " +
                $"Position: {_Position}";
        }

        public void SetBattingHistory(List<BattingRow> rows)
        {
            BattingHistory = rows;
        }

        public void SetPitchingHistory(List<PitchingRow> rows)
        {
            PitchingHistory = rows;
        }

        public void CalculateBattingInfo()
        {

            foreach(BattingRow row in BattingHistory)
            {
                int total = 0;

                total += (row.Hits - row.Doubles - row.Triples - row.Homeruns);
                total += (row.Doubles * 2);
                total += (row.Triples * 3);
                total += (row.Homeruns * 4);
                total += row.Runs;
                total += row.RBIs;
                total += (row.StolenBases * 2);
                total -= row.CaughtStealing;
                total += row.Walks;
                total -= row.StrikeOuts;

                row.GameAvg = (total / row.GamesPlayed);
                row.SeasonPointsTotal = total;

            }

        }

        public void CalculatePitchingInfo()
        {

            foreach (PitchingRow row in PitchingHistory)
            {
                double total = 0;

                total += row.OutsPitched * 0.75;
                total -= (row.EarnedRuns * 2);
                total += row.StrikeOuts;
                total -= row.Walks;
                total += row.Wins * 3;
                total += row.Saves * 2;
                total += (row.Losses * 5);

                row.GameAvg = (total / row.Games);
                row.SeasonPointsTotal = total;
            }
        }

        public bool CalculateScore()
        {
            try
            {
                List<double> scores = new List<double>();

                foreach (BattingRow row in BattingHistory)
                {
                    scores.Add(row.SeasonPointsTotal);
                }

                AvgScoreBySeason = scores.Mean();
                ScoreVarianceBySeason = scores.Variance();
                ScoreVarianceBySeason = scores.StandardDeviation();

            }
            catch
            {
                return false;
            }

            return true;
        }


    }
}
