using SuperNote.Application.Configuration.Commands;

namespace SuperNote.Application.Notes.CreateNote;

public record CreateNoteCommand(string Text) : ICommand<Guid>;