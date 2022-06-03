using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using WebApp;

namespace EnumResetTest;

public class NpgsqlEnumResetTest
{
    private readonly AppDbContext context;

    public NpgsqlEnumResetTest()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", false, true)
            .Build();

        var builder = new NpgsqlConnectionStringBuilder(configuration.GetConnectionString("DefaultConnection"));

        builder.Username = builder.Username ?? configuration["Connection:DefaultConnection:UserId"];
        builder.Password = builder.Password ?? configuration["Connection:DefaultConnection:Password"];

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(builder.ConnectionString);
        context = new AppDbContext(optionsBuilder.Options);
    }

    [Fact]
    public void TestNpgsqlDatabaseShouldReturnMyEnumFirst()
    {
        var entity = new MyEntity()
        {
            MyEnum = MyEnum.First
        };

        context.MyEntities.Add(entity);
        context.SaveChanges();

        Assert.Equal(MyEnum.First, entity.MyEnum);
    }
}
