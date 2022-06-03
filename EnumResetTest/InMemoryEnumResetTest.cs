using Microsoft.EntityFrameworkCore;
using WebApp;

namespace EnumResetTest;

public class InMemoryEnumResetTest
{
    private readonly AppDbContext context;

    public InMemoryEnumResetTest()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("MyInMemoryDatabseName");
        context = new AppDbContext(optionsBuilder.Options);
    }

    [Fact]
    public void TestInMemoryDatabaseShouldReturnMyEnumFirst()
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
