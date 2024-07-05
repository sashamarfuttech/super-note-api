# .NET 8 REST API Project That Implements Clean Architecture and Domain-Driven Design.

## Give a Star! :star:
If the project has been useful to you, please give it a star. Thank you!

## Description
SuperNote is the initial version of a note-taking app (such as [OneNote](https://www.onenote.com/) or [Notion](https://www.notion.so/)). There is no front-end at this time. The project contains a few REST API endpoints:

![image](https://github.com/sashamarfuttech/super-note-api/assets/158445722/ade6029e-bc2a-40f3-b371-94c95ed24116)

Technologies & Libraries:
1. [ASP.NET Core 8.0](https://learn.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-8.0?view=aspnetcore-8.0)
3. [Entity Framework Core 8](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-8.0/whatsnew)
2. [FastEndpoints 5.22.0](https://fast-endpoints.com/)
4. [MediatR 12.2.0](https://github.com/jbogard/MediatR)
5. [FluentResults 3.15](https://github.com/altmann/FluentResults)
6. [Optional 4.0](https://github.com/nlkl/Optional)

Databases:
1. [PostgreSQL](https://www.postgresql.org/) 
2. [Entity Framework Core 8 In-Memory Database](https://learn.microsoft.com/en-us/ef/core/providers/in-memory/?tabs=dotnet-core-cli)

## How do I run the application?
 1. Check out source code from the repository.
 2. Run **SuperNote.WebApi** project.

You'll see Swagger.

By default, the project is configured to use the Entity Framework In Memory database. 
So the above two steps will be enough if you want to have a quick play around with the app.

If you want to use a real database, then
 1. Create empty database.
 2. Go to the **appsettings.json** file and set the connection string in the **Sql:ConnectionString** section.
 3. Run the migrations defined in the **SuperNote.DataAccess** project.
 4. Run **SuperNote.WebApi** project.

The application uses a PostgreSQL database, but it can be easily changed it in the DataAccessServices.cs file if needed.

## Project Structure

The project implements a clean architecture. Here's its structure:

![Screenshot 2024-02-06 193709](https://github.com/sashamarfuttech/super-note-api/assets/158445722/c7b309dc-07b8-42cc-8982-33ec50e90cd1)

Now let's talk about each project separately.

**SuperNote.Domain**

The domain layer contains domain entities, domain events, repository interfaces, domain errors, and other core application logic.

**SuperNote.Application (Use cases)**

The application layer implements the SuperNote application use cases using Commands and Queries.
It also implements event handlers for domain events.

In addition, the application layer is where **abstractions** for caching, messaging, authentication, email notifications, and so on are placed.

**SuperNote.Infrastructure**

Currently, the infrastructure layer contains a single project, which is DataAccess. This project implements repositories, migrations, and other things related to data access.

In addition, the infrastructure layer must implement the caching, messaging, authentication, email notification abstractions that are defined in the application layer. 

**SuperNote.WebApi (Presentation)**

This is the entry point to the application. It implements a set of REST APIs that clients can use to interact with the application.

## Key Patterns

[REPR Design Pattern](https://deviq.com/design-patterns/repr-design-pattern)

REPR stands for Request, an Endpoint, and a Response. The pattern enforces the Single Responsibility Principle for your endpoints. The basic idea is that each request is handled by a separate class.

[Result Pattern](https://github.com/altmann/FluentResults)

There are two fundamental ways for handling invalid input in your domain: throw an exception or return an object indicating the error. The SuperNote application uses the second approach, returning a Result<T> object from the domain and application layers. You can read about the reasons for choosing one or the other [here](https://enterprisecraftsmanship.com/posts/exceptions-for-flow-control/), [here](https://www.silasreinagel.com/blog/2018/06/18/result-vs-exception/) or [here](https://softwareengineering.stackexchange.com/questions/405038/result-object-vs-throwing-exceptions).

