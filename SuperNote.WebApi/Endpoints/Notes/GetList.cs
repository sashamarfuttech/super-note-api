using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using SuperNote.Application.Notes.GetNotesList;

namespace SuperNote.WebApi.Endpoints.Notes;

[AllowAnonymous]
[HttpGet(ApiRoutes.Notes.GetList)]
public class GetList : Endpoint<EmptyRequest, IReadOnlyList<NotesListItemDto>>
{
    private readonly IMediator _mediator;

    public GetList(IMediator mediator) => _mediator = mediator;

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var notes = await _mediator.Send(new GetNotesListQuery(), ct);
        await SendOkAsync(notes, ct);
    }
}