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

        public void InitializeData()
        {
            // Build and store the results of the data query
            Console.WriteLine("Ran on startup!");
        }

        public string TestGetData()
        {
            // TODO go get real data
            Player = new Player(1, "Isaac", "Catcher");

            if (BaseballStatsDataHandler.IsValid() != null)
            {
                return Player.ToString();

            }
            return null;
        }
    }
}
