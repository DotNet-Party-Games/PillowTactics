using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PillowFight.Api.Models
{
    public class PlayerDetails
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }


    }
}
