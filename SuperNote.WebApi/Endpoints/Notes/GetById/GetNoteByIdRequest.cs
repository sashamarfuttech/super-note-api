using Microsoft.AspNetCore.Mvc;

namespace SuperNote.WebApi.Endpoints.Notes.GetById;

public class GetNoteByIdRequest
{
    [FromRoute] 
    public Guid NoteId { get; set; }
}