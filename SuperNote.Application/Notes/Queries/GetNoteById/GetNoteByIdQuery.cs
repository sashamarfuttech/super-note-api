using FluentResults;
using SuperNote.Application.Abstractions.Queries;
using SuperNote.Domain.Notes;

namespace SuperNote.Application.Notes.Queries.GetNoteById;

public record GetNoteByIdQuery(NoteId Id) : IQuery<Result<NoteDto>>;