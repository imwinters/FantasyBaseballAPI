using System;
namespace FantasyBaseball.Models
{
    public class Person
    {
        public string playerID { get; set; }
        public int BirthYear { get; set; }
        public int BirthMonth { get; set; }
        public int Birthday { get; set; }
        public string BirthCountry { get; set; }
        public string BirthState { get; set; }
        public string BirthCity { get; set; }
        public int DeathYear { get; set; }
        public int DeathMonth { get; set; }
        public int DeathDay { get; set; }
        public string DeathState { get; set; }
        public string DeathCity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public string Throws { get; set; }
        public string DebutDate { get; set; }
        public string FinalGameDate { get; set; }
        public string retroID { get; set; }
        public string bbrefID { get; set; }
        public string DeathCountry { get; internal set; }
    }
}
