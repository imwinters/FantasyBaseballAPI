
using System.Collections.Generic;
using FantasyBaseball.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FantasyBaseball.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        readonly DataHandler _data;

        public PlayersController(DataHandler data)
        {
            _data = data;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            yield return _data.TestGetData();
        }

    }
}
