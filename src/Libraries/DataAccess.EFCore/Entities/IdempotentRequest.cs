namespace DataAccess.EFCore.Entities
{
    public class IdempotentRequest
    {
        public Guid Id { get; set; }
        public string RequestKey { get; set; } = null!;
        public DateTime ProcessedAt { get; set; } = DateTime.UtcNow;
    }
}
