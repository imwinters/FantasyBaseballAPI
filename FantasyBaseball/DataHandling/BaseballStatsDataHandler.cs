
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using FantasyBaseball.Models;
using System;

namespace FantasyBaseball.DataHandling
{
    public static class BaseballStatsDataHandler
    {
        // TODO write data science methods and handlers here

        public static bool IsValid()
        {
            return true;
        }

        // TODO implement this functionallity with the data models/types from all the CSV Files
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
                    BattingRow currentLine = new BattingRow();
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
                Console.WriteLine(results[0].PlayerId);
                return results;
            }

            return null;
        }

        private static int ParseToInt(string field)
        {
            int currentValue;
            bool success = Int32.TryParse(field, out currentValue);
            if (success)
            {
                return currentValue;
            }

            return -1;
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

    }
}
