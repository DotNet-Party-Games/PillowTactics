using Microsoft.AspNetCore.Mvc;
using PillowFight.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PillowFight.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControlPanelController : ControllerBase
    {
        [HttpPost]
        public IPlayer Login(string userName, [FromBody] string password)
        {
            return null;
        }

        [HttpPost]
        public IPlayer Register(string userName, [FromBody] string password)
        {
            return null;
        }
    }
}

