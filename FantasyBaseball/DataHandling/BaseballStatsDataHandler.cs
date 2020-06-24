
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using FantasyBaseball.Models;
using System;

namespace FantasyBaseball.DataHandling
{
    public static class BaseballStatsDataHandler
    { 

        public static List<BattingRow> GatherBattingData(string path)
        {
            string battingCSVPath = path + "/Batting.csv";

            List<BattingRow> results = new List<BattingRow>();

            using (TextFieldParser csvParser = new TextFieldParser(battingCSVPath))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                // Skip the row with the column names
                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {

                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();

                    BattingRow row = new BattingRow();
                    
                    MapBattingRow(fields, row);

                    if(row.PlayerId != null)
                    {
                        results.Add(row);
                    }
                }

            }

            if (results.Count > 0)
            {
                return results;
            }

            return null;
        }

        public static List<PitchingRow> GatherPitchingData(string path)
        {
            string battingCSVPath = path + "/Pitching.csv";

            List<PitchingRow> results = new List<PitchingRow>();

            using (TextFieldParser csvParser = new TextFieldParser(battingCSVPath))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                // Skip the row with the column names
                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {

                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();

                    PitchingRow row = new PitchingRow();

                    MapPitchingRow(fields, row);

                    if (row.PlayerId != null)
                    {
                        results.Add(row);
                    }
                }
            }

            return results;
        }

        public static List<Person> GatherPersonData(string path)
        {
            string battingCSVPath = path + "/People.csv";

            List<Person> results = new List<Person>();

            using (TextFieldParser csvParser = new TextFieldParser(battingCSVPath))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                // Skip the row with the column names
                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {

                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();

                    Person row = new Person();

                    MapPersonRow(fields, row);

                    if (row.bbrefID != null)
                    {
                        results.Add(row);
                    }
                }

            }

            if (results.Count > 0)
            {
                return results;
            }

            return null;
        }

        private static PitchingRow MapPitchingRow(string[] fields, PitchingRow row)
        {
            int startingIndex = 0;


            row.PlayerId = fields[startingIndex++];
            row.YearId = ParseToInt(fields[startingIndex++]);
            row.Stint = ParseToInt(fields[startingIndex++]);
            row.TeamId = fields[startingIndex++];
            row.LeagueId = fields[startingIndex++];
            row.Wins = ParseToInt(fields[startingIndex++]);
            row.Losses = ParseToInt(fields[startingIndex++]);
            row.Games = ParseToInt(fields[startingIndex++]);
            row.GrandSlam = ParseToInt(fields[startingIndex++]);
            row.CompleteGame = ParseToInt(fields[startingIndex++]);
            row.Shutout = ParseToInt(fields[startingIndex++]);
            row.Saves = ParseToInt(fields[startingIndex++]);
            row.OutsPitched = ParseToInt(fields[startingIndex++]);
            row.Hits = ParseToInt(fields[startingIndex++]);
            row.EarnedRuns = ParseToInt(fields[startingIndex++]);
            row.Walks = ParseToInt(fields[startingIndex++]);
            row.StrikeOuts = ParseToInt(fields[startingIndex++]);
            row.OpponentsBattingAvg = ParseToInt(fields[startingIndex++]);
            row.EarnedRunAvg = ParseToInt(fields[startingIndex++]);
            row.IntentionalWalks = ParseToInt(fields[startingIndex++]);
            row.WildPitches = ParseToInt(fields[startingIndex++]);
            row.BattersHit = ParseToInt(fields[startingIndex++]);
            row.Balks = ParseToInt(fields[startingIndex++]);
            row.BattersFaced = ParseToInt(fields[startingIndex++]);
            row.GamesFinished = ParseToInt(fields[startingIndex++]);
            row.GroundIntoDoublePlayByOpponent = ParseToInt(fields[startingIndex++]);

            return row;
        }

        private static Person MapPersonRow(string[] fields, Person row)
        {
            int startingIndex = 0;

            row.playerID = fields[startingIndex++];
            row.BirthYear = ParseToInt(fields[startingIndex++]);
            row.BirthMonth = ParseToInt(fields[startingIndex++]);
            row.Birthday = ParseToInt(fields[startingIndex++]);
            row.BirthCountry = fields[startingIndex++];
            row.BirthState = fields[startingIndex++];
            row.BirthCity = fields[startingIndex++];
            row.DeathYear = ParseToInt(fields[startingIndex++]);
            row.DeathMonth = ParseToInt(fields[startingIndex++]);
            row.DeathDay = ParseToInt(fields[startingIndex++]);
            row.DeathCountry = fields[startingIndex++];
            row.DeathState = fields[startingIndex++];
            row.DeathCity = fields[startingIndex++];
            row.FirstName = fields[startingIndex++];
            row.LastName = fields[startingIndex++];
            row.Weight = ParseToInt(fields[startingIndex++]);
            row.DebutDate = fields[startingIndex++];
            row.FinalGameDate = fields[startingIndex++];
            row.retroID = fields[startingIndex++];
            row.bbrefID = fields[startingIndex];


            return row;
        }

        private static BattingRow MapBattingRow(string[] fields, BattingRow currentLine) {

            int startingIndex = 0;

            currentLine.PlayerId = fields[startingIndex++];
            currentLine.YearId = ParseToInt(fields[startingIndex++]);
            currentLine.Stint = ParseToInt(fields[startingIndex++]);
            currentLine.TeamId = fields[startingIndex++];
            currentLine.LeagueId = fields[startingIndex++];
            currentLine.GamesPlayed = ParseToInt(fields[startingIndex++]);
            currentLine.AtBats = ParseToInt(fields[startingIndex++]);
            currentLine.Runs = ParseToInt(fields[startingIndex++]);
            currentLine.Hits = ParseToInt(fields[startingIndex++]);
            currentLine.Doubles = ParseToInt(fields[startingIndex++]);
            currentLine.Triples = ParseToInt(fields[startingIndex++]);
            currentLine.Homeruns = ParseToInt(fields[startingIndex++]);
            currentLine.RBIs = ParseToInt(fields[startingIndex++]);
            currentLine.StolenBases = ParseToInt(fields[startingIndex++]);
            currentLine.CaughtStealing = ParseToInt(fields[startingIndex++]);
            currentLine.Walks = ParseToInt(fields[startingIndex++]);
            currentLine.StrikeOuts = ParseToInt(fields[startingIndex++]);
            currentLine.IntentionalWalks = ParseToInt(fields[startingIndex++]);
            currentLine.HitByPitch = ParseToInt(fields[startingIndex++]);
            currentLine.SacrficeHit = ParseToInt(fields[startingIndex++]);
            currentLine.SacrificeFly = ParseToInt(fields[startingIndex++]);
            currentLine.GroundIntoDoublePlay = ParseToInt(fields[startingIndex++]);

            return currentLine;
        }

        private static int ParseToInt(string field)
        {
            int currentValue;
            bool success = int.TryParse(field, out currentValue);
            if (success)
            {
                return currentValue;
            }

            return 0;
        }

    }
}
