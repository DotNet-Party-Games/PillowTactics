using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillowFight.Api.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }
    }
}
