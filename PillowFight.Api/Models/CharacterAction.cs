using PillowFight.Repositories.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillowFight.Api.Models
{
    public class CharacterAction
    {
        public int CharacterId { get; set; }

        public ActionTypeEnum ActionType { get; set; }

        public MapCoordinate Location { get; set; }
    }
}
