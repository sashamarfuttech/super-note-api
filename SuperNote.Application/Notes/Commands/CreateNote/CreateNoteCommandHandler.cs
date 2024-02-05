using Microsoft.Extensions.Logging;
using SuperNote.Application.Abstractions.Commands;
using SuperNote.Domain.Notes;
using SuperNote.Domain.SharedKernel.Repository;

namespace SuperNote.Application.Notes.Commands.CreateNote;

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