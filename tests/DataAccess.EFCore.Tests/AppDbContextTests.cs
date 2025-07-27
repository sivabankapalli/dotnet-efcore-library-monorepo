using DataAccess.EFCore;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class AppDbContextTests
{
    [Fact]
    public void CanInsertIdempotentRequest()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb").Options;
        using var db = new AppDbContext(options);
        db.IdempotentRequests.Add(new DataAccess.EFCore.Entities.IdempotentRequest
        {
            RequestKey = "test"
        });
        db.SaveChanges();
        Assert.Single(db.IdempotentRequests);
    }
}
