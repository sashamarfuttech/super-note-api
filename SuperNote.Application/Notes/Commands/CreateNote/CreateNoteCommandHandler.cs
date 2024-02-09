using FluentResults;
using SuperNote.Application.Abstractions.Commands;
using SuperNote.Domain.Abstractions.DataAccess;
using SuperNote.Domain.Notes;

namespace SuperNote.Application.Notes.Commands.CreateNote;

public class CreateNoteCommandHandler : ICommandHandler<CreateNoteCommand, Result<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly INotesRepository _notesRepository;
    private readonly TimeProvider _timeProvider;
    
    public CreateNoteCommandHandler(
        IUnitOfWork unitOfWork,
        INotesRepository notesRepository,
        TimeProvider timeProvider)
    {
        _unitOfWork = unitOfWork;
        _notesRepository = notesRepository;
        _timeProvider = timeProvider;
    }
    
    public async Task<Result<Guid>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var noteText = NoteText.Create(request.Text);

        if (noteText.IsFailed)
        {
            return Result.Fail(noteText.Errors);
        }

        Note note = new (noteText.Value, _timeProvider.GetUtcNow().UtcDateTime);
        
        _notesRepository.Add(note);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok<Guid>(note.Id.Value);
    }
}