using System.Reflection;

namespace Jacustran.Presentation.Registrations;

public static class AssemblyReference
{
    public static readonly Assembly Get = typeof(AssemblyReference).Assembly;
}
