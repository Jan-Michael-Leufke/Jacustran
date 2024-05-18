namespace Jacustran.Application.Features.Citites.Commands.PartialUpdateCity;

public class PartialUpsertCityCommand(Guid CityId, JsonPatchDocument<PartialUpsertCityPatchDto> PatchDocument) : ICommand<(Guid cityId, bool created)>
{
    public Guid CityId { get; set; } = CityId;
    public JsonPatchDocument<PartialUpsertCityPatchDto> PatchDocument { get; set; } = PatchDocument;

}
