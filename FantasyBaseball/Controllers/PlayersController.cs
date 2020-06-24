
using System;
using System.Collections.Generic;
using System.Linq;
using FantasyBaseball.Models;
using FantasyBaseball.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FantasyBaseball.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        readonly IDataHandler _data;

        public PlayersController(IDataHandler data)
        {
            _data = data;
        }


        [HttpGet]
        public string Get()
        {
            List<Player> results = _data.TestGetData();
            List<Player> sortedResults = results.OrderBy(o => o.AvgScoreBySeason).ToList();
            if (results == null)
            {
                return "Rebuild Data Pool";
            }
            var first50 = sortedResults.Skip(Math.Max(0, sortedResults.Count() - 50));
            string JSONString = JsonConvert.SerializeObject(first50.Reverse());
            return JSONString;
        }

    }
}
