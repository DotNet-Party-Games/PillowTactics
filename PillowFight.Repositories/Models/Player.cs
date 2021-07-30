using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillowFight.Repositories.Models
{
    class Player
    {
        public int PlayerId { get; set; }

        public int Losses { get; set; }

        public int Wins { get; set; }
    }
}
