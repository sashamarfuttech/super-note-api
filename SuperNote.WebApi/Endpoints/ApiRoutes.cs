namespace SuperNote.WebApi.Endpoints;

public static class ApiRoutes
{
    public static class Notes
    {
        public const string GroupName = nameof(Notes);
        
        public const string Create = $"/notes/";
        public const string GetList = $"/notes/";
        public const string GetById = $"/notes/{{noteId:guid}}/";
    }
}