using Microsoft.EntityFrameworkCore;
using CreatureWars.Class;
using CreatureWars.Formulas;


namespace ApplicationDatabase;

public class ApplicationContext : DbContext
{
    public DbSet<AbilityPrototype> AbilityPrototypes { get; set; }
    public DbSet<CreaturePrototype> CreaturePrototypes { get; set; }
    public DbSet<ItemPrototype> ItemPrototypes { get; set; }
    public DbSet<ModifierPrototype> ModifierPrototypes { get; set; }

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=creatures;Username=creatures;Password=creatures");
    }
}