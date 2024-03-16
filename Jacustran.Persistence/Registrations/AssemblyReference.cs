using System.Reflection;

namespace Jacustran.Application.Registrations;

public static class AssemblyReference
{
    public static readonly Assembly Get = typeof(AssemblyReference).Assembly;
}
