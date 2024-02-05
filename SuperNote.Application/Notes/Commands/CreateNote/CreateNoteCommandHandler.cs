using FluentResults;
using Microsoft.Extensions.Logging;
using SuperNote.Application.Abstractions.Commands;
using SuperNote.Domain.Notes;
using SuperNote.Domain.SharedKernel.Repository;

namespace SuperNote.Application.Notes.Commands.CreateNote;

public class CreateNoteCommandHandler : ICommandHandler<CreateNoteCommand, Result<Guid>>
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
    
    public async Task<Result<Guid>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var noteText = NoteText.Create(request.Text);

        if (noteText.IsFailed)
        {
            return Result.Fail(noteText.Errors);
        }
        
        Note note = new (noteText.Value);
        
        _notesRepository.Add(note);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok<Guid>(note.Id);
    }
}