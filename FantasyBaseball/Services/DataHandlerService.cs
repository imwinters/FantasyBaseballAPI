using System;
using FantasyBaseball.DataHandling;
using FantasyBaseball.Models;

namespace FantasyBaseball.Services
{
    public class DataHandler
    {
        private Player Player;

        public DataHandler()
        {
        }

        public void InitializeData(string path)
        {
            // Build and store the results of the data query
            Console.WriteLine("Gathering Data...");
            BaseballStatsDataHandler.GatherBattingData(path);
        }

        public string TestGetData()
        {
            // TODO go get real data
            Player = new Player(1, "Isaac", "Catcher");

            if (Player != null)
            {
                return Player.ToString();

            }
            return null;
        }
    }
}
