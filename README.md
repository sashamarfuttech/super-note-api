# .NET 8 REST API Project That Implements Clean Architecture and Domain-Driven Design.

## Give a Star! :star:
If the project has been useful to you, please give it a star. Thank you!

## Description
SuperNote is the initial version of a note-taking app (such as [OneNote](https://www.onenote.com/) or [Notion](https://www.notion.so/)).

Technologies & Libraries:
1. [ASP.NET Core 8.0](https://learn.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-8.0?view=aspnetcore-8.0)
2. [FastEndpoints](https://fast-endpoints.com/)
3. [Entity Framework Core 8](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-8.0/whatsnew)
4. [MediatR 12.2.0](https://github.com/jbogard/MediatR)
5. [FluentResults 3.15](https://github.com/altmann/FluentResults)

Databases:
1. [PostgreSQL](https://www.postgresql.org/) 
2. Entity Framework Core 8 In-Memory Database

## How do I run the application?
 1. Check out source code from the repository.
 2. Run **SuperNote.WebApi** project.

By default, the project is configured to use the Entity Framework In Memory database. 
So the above two steps will be enough if you want to have a quick play around with the app.

If you want to use a real database, then
 1. Create empty database.
 2. Go to the **appsettings.json** file and set the connection string in the **Sql:ConnectionString** section.
 3. Run the migrations defined in the **SuperNote.DataAccess** project.
 4. Run **SuperNote.WebApi** project.

The application uses a PostgreSQL database, but it can be easily changed it in the DataAccessServices.cs file if needed.

## Application Architecture

The project implements a clean architecture.

**SuperNote.Domain**

//TODO:

**SuperNote.Application**

//TODO:

**SuperNote.Infrastructure**

//TODO:

**SuperNote.WebApi**

//TODO:

## Implementation of Key Patterns

//TODO: 

## Error Handling

//TODO:


