# .NET 8 REST API Project That Implements Clean Architecture, DDD and CQRS.

## Give a Star! :star:
If the project has been useful to you, please give it a star. Thank you!

## Description
SuperNote is the initial version of a note-taking app (such as [OneNote](https://www.onenote.com/) or [Notion](https://www.notion.so/)).

## How do I run the application?
 1. Check out source code from the repository
 2. Run **SuperNote.WebApi** project

By default, the project is configured to use the Entity Framework In Memory database. 
So the above two steps will be enough if you want to have a quick play around with the app.

If you want to use a real database, then
 1. Create empty database.
 2. Go to the **appsettings.json** file and set the connection string in the **Sql:ConnectionString** section.
 3. Run the migrations defined in the **SuperNote.DataAccess** project.
 4. Run **SuperNote.WebApi** project

The application uses a PostgreSQL database, but it can be easily changed it in the DataAccessServices.cs file if needed.
