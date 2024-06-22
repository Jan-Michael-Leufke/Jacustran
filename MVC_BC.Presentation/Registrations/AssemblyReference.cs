using System.Reflection;

namespace MVC_BC.Presentation.Registrations;

public static class AssemblyReference
{
    public static readonly Assembly Get = typeof(AssemblyReference).Assembly;
}
