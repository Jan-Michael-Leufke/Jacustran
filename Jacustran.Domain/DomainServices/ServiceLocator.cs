using Microsoft.Extensions.DependencyInjection;

namespace Jacustran.Domain.DomainServices;

public static class ServiceLocator
{
    public static bool IsSet => _instance is not null;

    private static ServiceProvider? _instance;

    public static ServiceProvider Instance
    {
        get
        {
            if (_instance is null)
            {
                throw new InvalidOperationException("Service Provider not set");
            }

            return _instance;
        }
        set
        {
            if (_instance is not null)
            {
                throw new InvalidOperationException("Service Provider already set");
            }

            _instance = value;
        }
    }


    public static T GetService<T>() where T : notnull => Instance.GetRequiredService<T>(); 

}

