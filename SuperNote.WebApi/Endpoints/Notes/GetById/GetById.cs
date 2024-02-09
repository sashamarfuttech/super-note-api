using FastEndpoints;
using MediatR;
using SuperNote.Application.Notes.Queries.GetNoteById;
using SuperNote.Domain.Notes;
using SuperNote.WebApi.Extensions;

namespace SuperNote.WebApi.Endpoints.Notes.GetById;

public class GetById(IMediator mediator) : Endpoint<GetNoteByIdRequest, NoteDto>
{
    public override void Configure()
    {
        AllowAnonymous();
        
        Get(ApiRoutes.Notes.GetById);
        
        Summary(s =>
        {
            s.Summary = "Retrieve a note by its ID.";
        });
    }

    public override async Task HandleAsync(GetNoteByIdRequest req, CancellationToken ct)
    {
        var note = await mediator.Send(new GetNoteByIdQuery(new NoteId(req.NoteId)), ct);

        await (note.IsSuccess switch
        {
            true => SendOkAsync(note.Value, ct),
            false => this.SendProblemDetailsResponse(note, ct)
        });
    }
}