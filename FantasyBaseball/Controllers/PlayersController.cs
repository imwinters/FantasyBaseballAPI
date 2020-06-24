
using System.Collections.Generic;
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
            if (results == null)
            {
                return "Rebuild Data Pool";
            }
            List<Player> first50 = results.GetRange(0, 50);
            string JSONString = JsonConvert.SerializeObject(first50);
            return JSONString;
        }

    }
}
