using System.Reflection;
using SuperNote.Application;

namespace SuperNote.WebApi;

public static class AssemblyReferences
{
    public static readonly Assembly WebApi = typeof(Program).Assembly;
    public static readonly Assembly Application = typeof(ApplicationServices).Assembly;
}