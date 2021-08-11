using System.Collections.Generic;

namespace PillowFight.Api.Models
{
    public class ActionTypeOptions
    {
        public string ActionType { get; set; }

        public IEnumerable<MapPosition> Targets { get; set; }
    }
}
