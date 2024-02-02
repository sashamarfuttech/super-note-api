using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuperNote.Application.Notes.CreateNote;
using SuperNote.Application.Notes.GetNotesList;

namespace SuperNote.WebApi.Endpoints;

public class CreateNoteRequest
{
    public string Text { get; set; }
}

public static class NotesModule
{
    public static void AddNotesEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/note", async (IMediator mediator,
            [FromBody] CreateNoteRequest request) =>
        {
            await mediator.Send(new CreateNoteCommand(request.Text));

            return Results.Ok();
        });
        
        app.MapGet("/notes", async (IMediator mediator) =>
        {
            var notes = await mediator.Send(new GetNotesListQuery());

            return Results.Ok(notes);
        });
    }
}