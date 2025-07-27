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

## Local Development: Running PostgreSQL with Docker Compose

For easy local testing, this repo provides a ready-to-go PostgreSQL database using Docker Compose.

1. Start the DB:
    ```bash
    docker-compose up -d
    ```
2. Run migrations as needed.
3. When finished:
    ```bash
    docker-compose down
    ```

_Default credentials are set in both `docker-compose.yml` and `appsettings.json`._

## License

MIT
