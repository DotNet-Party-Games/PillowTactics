using PillowFight.Repositories.Enumerations;

namespace PillowFight.Api.Models
{
    public class ActionTypeOption
    {
        public ActionTypeEnum ActionType { get; set; }

        public MapCoordinate Location { get; set; }
    }
}
