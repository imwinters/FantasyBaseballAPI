using System;
using FantasyBaseball.Models;

namespace FantasyBaseball.Services
{
    public class DataHandler
    {
        private PlayerDomainModel Player;

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
            Player = new PlayerDomainModel(1, "Isaac", "Catcher");

            if (Player != null)
            {
                return Player.ToString();

            }
            return null;
        }
    }
}
