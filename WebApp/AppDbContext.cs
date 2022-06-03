using Microsoft.EntityFrameworkCore;

namespace WebApp;

public class AppDbContext : DbContext
{
    public DbSet<MyEntity> MyEntities { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MyEntity>()
            .Property(_ => _.MyEnum)
            .HasDefaultValue(MyEnum.Second)
            .HasConversion<string>();
    }
}
