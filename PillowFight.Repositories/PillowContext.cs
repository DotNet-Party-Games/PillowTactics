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
        public PillowContext (DbContextOptions<PillowContext> options) : base(options)
        { }
        public PillowContext () : base()
        { }
        //public DbSet<ArmorItem> ArmorItems { set; get; }
        //public DbSet<Character> Characters { set; get; }
        //public DbSet<Item> Items { set; get; }
        public DbSet<Player> Players { set; get; }
        //public DbSet<PlayerCharacter> PlayerCharacters { set; get; }
        //public DbSet<SpellItem> SpellItems { set; get; }
        //public DbSet<WeaponItem> Weapontems { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseNpgsql("Server=batyr.db.elephantsql.com;Database=moaualdq;User Id=moaualdq;Password=Jn2Z94Le1pwLHC-pJwaWSxBXQC7iXpQd");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("PillowFight");
        }
    }
}
