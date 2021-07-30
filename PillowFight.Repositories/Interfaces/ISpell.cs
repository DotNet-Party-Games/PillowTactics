namespace PillowFight.Repositories.Interfaces
{
    public interface ISpell : IWeapon
    {
        public int Cost { get; set; }
    }
}
