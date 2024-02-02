namespace SuperNote.WebApi.Endpoints;

public static class ApiRoutes
{
    private const string ApiPrefix = "/api";
    
    public static class Notes
    {
        public const string Create = $"{ApiPrefix}/notes";
        public const string GetList = $"{ApiPrefix}/notes";
    }
}