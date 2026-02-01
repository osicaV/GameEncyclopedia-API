# GameEncyclopedia

A portfolio project: REST API built with ASP.NET Core to manage game encyclopedia data.
Starting with **Monsters** (CRUD + Swagger), then progressively adding persistence, validation, tests, and CI.

## Current state
- ASP.NET Core Web API template
- Swagger / OpenAPI enabled

## Tech Stack
- ASP.NET Core Web API (.NET)
- Swagger / OpenAPI
- EF Core + Database (planned)
- Tests + CI (planned)

## Getting Started
1. Restore dependencies:
   - `dotnet restore`
2. Run the API:
   - `dotnet run`
3. Open Swagger:
   - `/swagger`

## Roadmap (MVP)
- [ ] Monsters domain model
- [ ] EF Core + migrations
- [ ] CRUD endpoints for Monsters
- [ ] DTO validation
- [ ] Pagination + filtering
- [ ] Unit + integration tests
- [ ] GitHub Actions (build + test)

## Notes
This repository is developed step by step with small, incremental commits.
