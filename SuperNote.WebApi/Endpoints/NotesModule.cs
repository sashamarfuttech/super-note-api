namespace SuperNote.WebApi.Endpoints;

public static class NotesModule
{
    public static void AddNotesEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/notes", () =>
        {
            return Results.Ok("my notes");
        });
    }
}