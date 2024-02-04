using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace SuperNote.WebApi.Endpoints.Notes.Models;

public class GetNoteRequest
{
    [FromRoute] 
    public Guid NoteId { get; set; }
}