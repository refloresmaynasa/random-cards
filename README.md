# Random Cards

Practice repository for a Random Cards application in .Net Core

### Tools

- .NET 5
- Entity Framework Core
- Ardalis.Specification (Entity Framework - repository)
- MediatR
- FluentValidation
- Automapper
- PostgreSQL
- JWT (authentication)
- Docker
  - docker-compose

## Initial configurations

### Create the databases

* Start the Database

  ```powershell
  docker-compose up postgresDb
  ```

* Make sure the Startup Project is **WebApi** (Set as Startup Project) and Connection Strings are correct in *appsettings.json*

* Execute migration on **Identity** project (Package Manager Console)

  ```powershell
  Add-Migration InitialMigration -Context IdentityContext
  ```

  ```powershell
  Update-Database -Context IdentityContext
  ```

* Execute migration on **Persistence** project (Package Manager Console)

  ```powershell
  Add-Migration InitialMigration -Context CatalogDbContext
  ```

  ```powershell
  Update-Database -Context CatalogDbContext
  ```

* 

## Start Application

Set WebApi as Startup Project, and go into WebApi folder.

```powershell
dotnet run
```

Login (as administrator) on ***/api/v1/Account/authenticate***:

* email: userAdmin@mail.com
* password: Password999!



