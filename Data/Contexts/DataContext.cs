using Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;
public class DataContext(DbContextOptions<DataContext>options) : DbContext(options)
{
  public DbSet<EventEntity> Event { get; set; }
  public DbSet<EventPackageEntity> EventPackage { get; set; }
  public DbSet<PackageEntity> Package { get; set; }
}
