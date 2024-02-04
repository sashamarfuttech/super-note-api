using FluentResults;
using SuperNote.Application.Configuration.Queries;
using SuperNote.Domain.Notes;

namespace SuperNote.Application.Notes.GetNote;

public record GetNoteQuery(NoteId Id) : IQuery<Result<NoteDto>>;