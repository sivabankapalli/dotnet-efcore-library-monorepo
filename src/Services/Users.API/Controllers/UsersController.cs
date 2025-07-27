using Microsoft.AspNetCore.Mvc;
using DataAccess.EFCore;
using DataAccess.EFCore.Idempotency;

namespace Users.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IdempotencyService _idempotency;

        public UsersController(AppDbContext db, IdempotencyService idempotency)
        {
            _db = db;
            _idempotency = idempotency;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateRequest request)
        {
            if (await _idempotency.IsDuplicateAsync(request.IdempotencyKey))
                return Conflict("Request already processed.");

            using var tx = await _db.Database.BeginTransactionAsync();
            // ... business logic here ...

            await _idempotency.MarkProcessedAsync(request.IdempotencyKey);
            await tx.CommitAsync();
            return Ok("Created");
        }
    }

    public class UserCreateRequest
    {
        public string IdempotencyKey { get; set; }
        // Other properties...
    }
}
