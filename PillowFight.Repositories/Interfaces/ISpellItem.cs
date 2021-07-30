namespace PillowFight.Repositories.Interfaces
{
    public interface ISpellItem : IWeaponItem
    {
        public int Cost { get; set; }
    }
}
