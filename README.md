![.NET Core](https://github.com/ShadyNagy/Swagger/workflows/.NET%20Core/badge.svg)
![Publish to Azure](https://github.com/ShadyNagy/Swagger/workflows/publish/badge.svg)

### Swagger
Source code for Implement Swagger with username and password.

## Give a Star! :star:

If you like or are using this project to learn or start your solution, please give it a star. Thanks!

## Animated Screenshots

### Working with Swagger by Username and Password.
![SwaggerLogin](https://user-images.githubusercontent.com/6225593/86539218-12d15980-befb-11ea-8015-56b23e3aaa1b.gif)


## Migration Scripts

## Create migrations:
```powershell
dotnet ef migrations add InitialModel --context appdbcontext -p ../ShadyNagy.Swagger.Infrastructure/ShadyNagy.Swagger.Infrastructure.csproj -s ShadyNagy.Swagger.Api.csproj -o Data/Migrations

dotnet ef migrations add InitialIdentityModel --context appidentitydbcontext -p ../ShadyNagy.Swagger.Infrastructure/ShadyNagy.Swagger.Infrastructure.csproj -s ShadyNagy.Swagger.Api.csproj -o Identity/Migrations
```

## Apply migrations:

```powershell
dotnet ef database update -c appdbcontext -p ../ShadyNagy.Swagger.Infrastructure/ShadyNagy.Swagger.Infrastructure.csproj -s ShadyNagy.Swagger.Api.csproj
dotnet ef database update -c appidentitydbcontext -p ../ShadyNagy.Swagger.Infrastructure/ShadyNagy.Swagger.Infrastructure.csproj -s ShadyNagy.Swagger.Api.csproj
```

## Generate script:

```powershell
dotnet ef migrations script --context appidentitydbcontext -p ../ShadyNagy.Swagger.Infrastructure/ShadyNagy.Swagger.Infrastructure.csproj -s ShadyNagy.Swagger.Api.csproj | out-file ./script.sql
```

## Dependencies:

[Ardalis.CleanArchitecture](https://github.com/ardalis/CleanArchitecture)
[Ardalis.ApiEndpoints](https://github.com/ardalis/ApiEndpoints)
AutoMapper
MediatR
Swashbuckle.AspNetCore
Microsoft.EntityFrameworkCore

