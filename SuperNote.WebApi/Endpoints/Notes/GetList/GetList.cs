using FastEndpoints;
using MediatR;
using SuperNote.Application.Notes.Queries.GetNotesList;

namespace SuperNote.WebApi.Endpoints.Notes.GetList;

public class GetList(IMediator mediator) : Endpoint<EmptyRequest, IReadOnlyList<NotesListItemDto>>
{
    public override void Configure()
    {
        AllowAnonymous();
        
        Get(ApiRoutes.Notes.GetList);
        
        Summary(s =>
        {
            s.Summary = "Returning the list of notes.";
        });
    }
    
    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var notes = await mediator.Send(new GetNotesListQuery(), ct);
        await SendOkAsync(notes, ct);
    }
}