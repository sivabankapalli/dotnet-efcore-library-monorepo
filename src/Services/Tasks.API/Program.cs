var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddAppDbContext(builder.Configuration);
builder.Services.AddScoped<DataAccess.EFCore.Idempotency.IdempotencyService>();
var app = builder.Build();
app.MapControllers();
app.Run();
