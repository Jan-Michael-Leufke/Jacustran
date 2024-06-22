using Jacustran.Application.Modelbinders;
using Microsoft.AspNetCore.Mvc;

namespace Jacustran.Application.Features.Citites.Queries.GetCityCollection;

public class GetCityCollectionRequest : BaseRequest
{
    public const string Route = "api/cityCollections/{cityIds}";


    [ModelBinder(typeof(EnumerableArrayModelBinderType<Guid>))]
    [FromRoute]
    public IEnumerable<Guid> CityIds { get; set; } = [];

}
