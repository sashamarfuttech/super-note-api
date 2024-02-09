using Moq;
using Optional;
using SuperNote.Application.Notes.Queries.GetNoteById;
using SuperNote.Domain.Notes;

namespace SuperNote.Application.Tests.Notes.QueryHandlers;

public class GetNoteByIdQueryHandlerTests
{
    private readonly Mock<INotesRepository> _notesRepositoryMock = new ();

    private readonly GetNoteByIdQueryHandler _sut;
    
    public GetNoteByIdQueryHandlerTests()
    {
        _sut = new (_notesRepositoryMock.Object);
    }

    [Fact]
    public async Task Get_note_by_id_returns_error_when_note_does_not_exist()
    {
        // Arrange
        _notesRepositoryMock
            .Setup(x => x.GetByIdAsync(It.IsAny<NoteId>()))
            .ReturnsAsync(Option.None<Note>());
        
        // Act
        var result = await _sut.Handle(new GetNoteByIdQuery(It.IsAny<NoteId>()), default);
        
        // Assert
        var contains = result.Errors.Contains(NoteErrors.NoteNotFound);
        Assert.True(contains);
    }

    [Fact]
    public async Task Get_note_by_id_returns_a_note()
    {
        // Arrange
        var noteText = NoteText.Create("text");
        var note = new Note(noteText.Value, DateTime.Now);
        
        NoteDto expectedNoteDto = new (note.Id.Value, note.NoteText.Value, note.LastModified);
        
        _notesRepositoryMock
            .Setup(x => x.GetByIdAsync(note.Id))
            .ReturnsAsync(note.Some());
        
        // Act
        var noteDto = await _sut.Handle(new GetNoteByIdQuery(note.Id), default);

        // Assert
        Assert.Equal(expectedNoteDto, noteDto.Value);
    }
}