using Microsoft.EntityFrameworkCore;

namespace CreatureWars.Class 
{
    class GameContext : DbContext
    {
        // public GameContext()
        // {
        //     Database.EnsureCreated();
        // }

        //Prototype entities
        public DbSet<ModifierPrototype> ModifierPrototypes { get; set; }
        public DbSet<ItemPrototype> ItemPrototypes { get; set; }
        public DbSet<AbilityPrototype> AbilityPrototypes { get; set; }
        public DbSet<CreaturePrototype> CreaturePrototypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;Database=creatures;User=root;Password=root;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

    }
}
