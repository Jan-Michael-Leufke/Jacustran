
namespace Jacustran.Domain.City;

public static class CityErrors
{
    public static readonly Error ValidationError = new Error("City.ValidationError", "The Validation didn´t check out.");

    public static Error NotFound(Guid cityGuid) => new Error("City.NotFound", $"City with id {cityGuid} was not found");

    public static Error NoneFound(IEnumerable<Guid> CityGuids) => new Error("City.NoneFound", $"No Cities were found with the " +
        $"following Ids: {string.Join(", ", CityGuids)}");

    public static Error SomeNotFound(IEnumerable<Guid> cityIds) => new Error("City.SomeNotFound", $"There is" +
        $"a mismatch between the amount of ids and the amount of cities assotiated with them. Invalid Key");
}


public static partial class DomainErrors
{
    public static class TestErrors
    {
        public static Error TestError = new Error("Test.Error", "This is a test error");
    }
}



public static partial class DomainErrors
{
    public static class TestErrorsAgain
    {
        public static Error TestErrorAgain = new Error("Test.ErrorAgain", "This is a another testf error");
    }
}


public class Something
{
    public void Test()
    {
        var res = DomainErrors.TestErrors.TestError;
        var res2 = DomainErrors.TestErrorsAgain.TestErrorAgain;
    }
}