using System.Collections.Generic;
using FantasyBaseball.Models;

namespace FantasyBaseball.Services
{
    public interface IDataHandler
    {
        List<Player> TestGetData();
        void InitializeData(string path);
    }
}