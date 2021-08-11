using System.Collections.Generic;

namespace PillowFight.Api.Models
{
    public class ActionTypeTargets
    {
        public string ActionType { get; set; }

        public IEnumerable<MapPosition> Targets { get; set; }
    }
}
