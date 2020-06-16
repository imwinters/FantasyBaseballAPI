using System.Collections.Generic;

namespace FantasyBaseball.Models
{
    public class Player
    {
        private int _Id;
        private string _Name;
        private string _Position;
        private List<BattingRow> BattingHistory;

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

    }
}
