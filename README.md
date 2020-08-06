## Ride-hailing-company-api (work in-progress)
RESTful API for managing ride-hailing company. Developed in ASP.NET Core 3.1.

### Tools and patterns
- ASP.NET Core Identity (JWT)
- Entity Framework Core with SQL Server
- Automapper
- FluentValidation
- Mediator (with MediatR)
- Clean architecture
- Domain-Driven Design


### Configuration and launch
Update `appsettings.json` with connection strings for application data database and identity database and execute the following commands from `Api` folder: 
```
dotnet ef database update --context IdentityDbContext -p ../Infrastructure/Infrastructure.csproj
dotnet ef database update --context RideHailingContext -p ../Infrastructure/Infrastructure.csproj
dotnet run
```
