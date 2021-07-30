using PillowFight.Repositories.Enumerations;

namespace PillowFight.Repositories.Interfaces
{
    public interface IArmor : IItem
    {
        public int Defense { get; set; }
    }
}
