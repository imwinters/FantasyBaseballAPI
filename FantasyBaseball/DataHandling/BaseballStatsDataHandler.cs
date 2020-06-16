using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

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
        public static List<List<string>> GatherData(string path)
        {
            List<List<string>> results = new List<List<string>>();

            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                // Skip the row with the column names
                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {
                    List<string> currentLine = new List<string>();
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();
                    currentLine.Add(fields[0]);
                    currentLine.Add(fields[1]);

                    if(currentLine.Count > 0)
                    {
                        results.Add(currentLine);
                    }
                }

            }

            if (results.Count > 0)
            {
                return results;
            }

            return null;
        }


    }
}
