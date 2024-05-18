namespace Jacustran.Application.Features.Citites.Queries.GetCityCollection;

public class GetCityCollectionResponse(IEnumerable<GetCityCollectionVm> getCityCollectionVms) : BaseResponse
{
    public IEnumerable<GetCityCollectionVm> Cities { get; set; } = getCityCollectionVms;
    
}
