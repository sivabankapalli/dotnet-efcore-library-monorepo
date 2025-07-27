# dotnet-efcore-library-monorepo

A monorepo solution for .NET microservices using a shared EF Core library, supporting migrations and idempotency.

## Quick Start

1. Clone the repo and open in Visual Studio or Rider.
2. Add your connection string under each API's `appsettings.json`.
3. Add the DbContext to your API:
    ```csharp
    services.AddAppDbContext(Configuration);
    services.AddScoped<IdempotencyService>();
    ```
4. Run migrations:
    ```bash
    dotnet ef migrations add Init --context AppDbContext --project ./src/Libraries/DataAccess.EFCore --startup-project ./src/Services/Tasks.API
    dotnet ef database update --project ./src/Libraries/DataAccess.EFCore --startup-project ./src/Services/Tasks.API
    ```
5. Test with `dotnet test`.

## Folder Structure

- `src/Libraries/DataAccess.EFCore` — the shared EF Core library
- `src/Services/Tasks.API` and `Users.API` — sample consumers
- `tests/` — integration and unit tests

## Migrations & Idempotency

- Migrations managed via the shared library with context factory.
- Idempotency supported out-of-the-box via `IdempotentRequests` table and `IdempotencyService`.

## License

MIT
