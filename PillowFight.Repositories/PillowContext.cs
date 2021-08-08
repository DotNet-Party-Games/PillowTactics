using Microsoft.EntityFrameworkCore;
using PillowFight.Repositories.Models;

namespace PillowFight.Repositories
{
    public class PillowContext : DbContext
    {
        public PillowContext(DbContextOptions options) : base(options)
        { }

        public DbSet<ArmorItem> ArmorItems { set; get; }
        public DbSet<Character> Characters { set; get; }
        public DbSet<Item> Items { set; get; }
        public DbSet<Player> Players { set; get; }
        public DbSet<PlayerCharacter> PlayerCharacters { set; get; }
        public DbSet<InventoryItem> Inventory { get; set; }
        public DbSet<SpellItem> SpellItems { set; get; }
        public DbSet<WeaponItem> WeaponItems { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Player>()
                .HasIndex(b => b.UserName)
                .IsUnique();

            modelBuilder.Entity<Character>()
                .HasOne(l_character => l_character.TorsoSlotItem)
                .WithMany()
                .HasForeignKey(l_character => l_character.TorsoSlotItemId);
            modelBuilder.Entity<Character>()
                .HasOne(l_character => l_character.MainHandSlotItem)
                .WithMany()
                .HasForeignKey(l_character => l_character.MainHandSlotItemId);

            modelBuilder.Entity<InventoryItem>()
                .HasOne(l_inventoryItem => l_inventoryItem.Player)
                .WithMany(l_player => l_player.Inventory)
                .HasForeignKey(l_player => l_player.PlayerId);
            modelBuilder.Entity<InventoryItem>()
                .HasAlternateKey(l_inventoryItem => new { l_inventoryItem.PlayerId, l_inventoryItem.ItemId });
        }
    }
}
