using MediatR;
using SuperNote.Application.Notes.GetNotes;

namespace SuperNote.WebApi.Endpoints;

public static class NotesModule
{
    public static void AddNotesEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/note/", async (IMediator mediator) =>
        {
            GetNotesQuery query = new (Guid.NewGuid());

            var note = await mediator.Send(query);
            
            return Results.Ok(note);
        });
    }
}