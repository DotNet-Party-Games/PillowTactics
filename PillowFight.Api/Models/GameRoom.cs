using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillowFight.Api.Models
{
    public class GameRoom
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsPrivate { get; set; }

        public int? Player1Id { get; set; }

        public int? Player2Id { get; set; }
    }
}
