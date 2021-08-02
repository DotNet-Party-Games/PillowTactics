using PillowFight.Repositories.Enumerations;

namespace PillowFight.Repositories.Interfaces
{
    public interface IArmorItem : IItem
    {
        public int Id { get; set; }
        public int Defense { get; set; }
    }
}
