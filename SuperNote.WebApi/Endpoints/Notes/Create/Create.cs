using FastEndpoints;
using MediatR;
using SuperNote.Application.Notes.Commands.CreateNote;

namespace SuperNote.WebApi.Endpoints.Notes.Create;

public class Create(IMediator mediator) : Endpoint<CreateNoteRequest, CreateNoteResponse>
{
    public override void Configure()
    {
        AllowAnonymous();
        
        Post(ApiRoutes.Notes.Create);
        
        Summary(s =>
        {
            s.Summary = "Create a new note.";
        });
    }

    public override async Task HandleAsync(CreateNoteRequest req, CancellationToken ct)
    {
        var id = await mediator.Send(new CreateNoteCommand(req.Text), ct);
        
        await SendOkAsync(new CreateNoteResponse(id), ct);
    }
}