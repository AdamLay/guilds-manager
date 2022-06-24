using Microsoft.EntityFrameworkCore;

namespace GuildsManager.Web.Data;

public class GuildsDbContext : DbContext
{
  public GuildsDbContext(DbContextOptions<GuildsDbContext> options) :
    base(options)
  {
  }
  
  public DbSet<Faction> Factions { get; set; }
  public DbSet<ModelCard> ModelCards { get; set; }
  public DbSet<Ability> Abilities { get; set; }
  public DbSet<Attack> Attacks { get; set; }
}