using SuperNote.Application.Configuration.Commands;
using SuperNote.Domain;
using SuperNote.Domain.Notes;

namespace SuperNote.Application.Notes.CreateNote;

public class CreateNoteCommandHandler : ICommandHandler<CreateNoteCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly INotesRepository _notesRepository;

    public CreateNoteCommandHandler(
        IUnitOfWork unitOfWork,
        INotesRepository notesRepository)
    {
        _unitOfWork = unitOfWork;
        _notesRepository = notesRepository;
    }

    public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        Note note = new (request.Text);
        
        _notesRepository.Add(note);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return note.Id;
    }
}