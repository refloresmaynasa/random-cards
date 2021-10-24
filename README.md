# Random Cards

Practice repository for a Random Cards application in .Net Core

### Tools

- .NET 5
- Entity Framework Core
- MediatR
- FluentValidation
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
  Add-Migration InitialMigration
  Update-Database
  ```

* 

