using Microsoft.EntityFrameworkCore;
using PillowFight.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillowFight.Repositories
{
    public class PillowContext : DbContext
    {
        public PillowContext (DbContextOptions options) : base(options)
        { }
        public PillowContext () : base()
        { }
        public DbSet<ArmorItem> ArmorItems { set; get; }
        public DbSet<Character> Characters { set; get; }
        public DbSet<Item> Items { set; get; }
        public DbSet<Player> Players { set; get; }
        public DbSet<PlayerCharacter> PlayerCharacters { set; get; }
        public DbSet<SpellItem> SpellItems { set; get; }
        public DbSet<WeaponItem> WeaponItems { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseNpgsql("Server=chunee.db.elephantsql.com;Database=kjmdumdn;User Id=kjmdumdn;Password=J-hZQv_m_KH_1Q-Li86wm9Bj6Yv9Cp9I");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("PillowFight");
        }
    }
}
