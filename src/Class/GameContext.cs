﻿using Microsoft.EntityFrameworkCore;

namespace CreatureWars.Class 
{
    internal class GameContext : DbContext
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
            optionsBuilder.UseMySql("Server=localhost;Database=creatures;User=root;Password=root;");
        }

    }
}
