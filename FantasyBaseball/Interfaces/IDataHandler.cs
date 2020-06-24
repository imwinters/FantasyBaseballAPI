using System.Collections.Generic;
using FantasyBaseball.Models;

namespace FantasyBaseball.Services
{
    public interface IDataHandler
    {
        Results TestGetData();
        void InitializeData(string path);
    }
}