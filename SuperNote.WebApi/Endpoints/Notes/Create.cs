using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using SuperNote.Application.Notes.CreateNote;
using SuperNote.WebApi.Endpoints.Notes.Models;

namespace SuperNote.WebApi.Endpoints.Notes;

[AllowAnonymous]
[HttpPost(ApiRoutes.Notes.Create)]
public class Create : Endpoint<CreateNoteRequest, EmptyResponse>
{
    private readonly IMediator _mediator;

    public Create(IMediator mediator) => _mediator = mediator;

    public override async Task HandleAsync(CreateNoteRequest req, CancellationToken ct)
    {
        await _mediator.Send(new CreateNoteCommand(req.Text), ct);
        await SendOkAsync(ct);
    }
}