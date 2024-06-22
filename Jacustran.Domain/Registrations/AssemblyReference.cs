using System.Reflection;

namespace Jacustran.Domain.Registrations;

public static class AssemblyReference
{
    public static readonly Assembly Get = typeof(AssemblyReference).Assembly;
}

