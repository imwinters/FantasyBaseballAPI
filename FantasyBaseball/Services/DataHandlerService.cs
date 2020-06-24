using System;
using System.Collections.Generic;
using FantasyBaseball.DataHandling;
using FantasyBaseball.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBaseball.Services
{
    public class DataHandler : IDataHandler
    {
        private IMemoryCache _cache;

        public DataHandler(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public void InitializeData(string path)
        {
            Console.WriteLine("Gathering Data...");

            Results cacheEntry = new Results();

            List<PitchingRow> pitchingData = BaseballStatsDataHandler.GatherPitchingData(path);
            List<BattingRow> battingData = BaseballStatsDataHandler.GatherBattingData(path);
            List<Person> personInfo = BaseballStatsDataHandler.GatherPersonData(path);

            List<Player> tempList = new List<Player>();
            List<Player> finalPlayers = new List<Player>();

            int personCount = 0;

            foreach (Person person in personInfo)
            {

                if (tempList.Where(i => i.Id == person.playerID).Count() == 0)
                {
                    Player tempPlayer = new Player(person.playerID, person.FirstName + " " + person.LastName, person.Throws );

                    tempList.Add(tempPlayer);
                    personCount++;
                    
                }
            }


            Console.WriteLine($"Total Players {personCount}");

            Console.WriteLine("Calculating Batting Data...");

            Parallel.ForEach(battingData, row =>
            {
                row.CalculateBattingInfo();

                foreach (Player player in tempList.Where(i => i.Id == row.PlayerId))
                {
                    if (player.BattingHistory == null)
                    {
                        player.BattingHistory = new List<BattingRow>();
                    }
                    player.BattingHistory.Add(row);
                }
            });


            Console.WriteLine("Batting Data Finished");


            Console.WriteLine("Calculating Pitching Data...");

            Parallel.ForEach(pitchingData, row =>
            {
                row.CalculatePitchingInfo();

                foreach (Player player in tempList.Where(i => i.Id == row.PlayerId))
                {
                    if (player.PitchingHistory == null)
                    {
                        player.PitchingHistory = new List<PitchingRow>();
                    }
                    player.PitchingHistory.Add(row);
                }
            });


            Console.WriteLine("Pitching Data Finished");

            Parallel.ForEach(tempList, player =>
            {
                player.CalculateScore();
                player.CalculatePitchingScore();
            });


            cacheEntry.Pitchers = tempList.Where(i => i.PitchingHistory.Count != 0 || i.PitchingHistory != null);

                // Look for cache key.
            if (!_cache.TryGetValue(CacheKeys.Players, out cacheEntry))
            {

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions();

                // Save data in cache.
                // TODO replate templist once position data is added
                _cache.Set(CacheKeys.Players, tempList, cacheEntryOptions);
            }

            // Build and store the results of the data query
            Console.WriteLine("Data Processed!");

            

        }

        

        public Results TestGetData()
        {
            IEnumerable<Player> results;

            _cache.TryGetValue(CacheKeys.Players, out results);

            Results final = new Results();

            final.Pitchers = results.Where(i => i.PitchingHistory != null);

            return final;

        }
    }
}
