using SuperNote.Application.Abstractions.Commands;

namespace SuperNote.Application.Notes.Commands.CreateNote;

public record CreateNoteCommand(string Text) : ICommand<Guid>;