using SuperNote.Domain.Notes;

namespace SuperNote.Domain.Tests.Notes;

public class NoteTextTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Note_text_is_not_created_without_data(string data)
    {
        // Act
        var noteText = NoteText.Create(data);
        
        // Assert
        Assert.True(noteText.IsFailed);
    }

    [Fact]
    public void Note_text_is_created()
    {   
        // Act
        var noteText = NoteText.Create("I need to schedule a meeting with John Doe");
        
        // Assert
        Assert.True(noteText.IsSuccess);
    }
}