using DataAccess.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFCore.Idempotency
{
    public class IdempotencyService
    {
        private readonly AppDbContext _db;

        public IdempotencyService(AppDbContext db) => _db = db;

        public async Task<bool> IsDuplicateAsync(string key)
            => await _db.IdempotentRequests.AnyAsync(r => r.RequestKey == key);

        public async Task MarkProcessedAsync(string key)
        {
            _db.IdempotentRequests.Add(new IdempotentRequest { RequestKey = key });
            await _db.SaveChangesAsync();
        }
    }
}
