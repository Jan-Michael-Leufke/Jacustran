﻿namespace Jacustran.Application.Features.Shared.Spots;

public abstract class SpotForManipulationDtoBase 
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public StarRating StarRating { get; set; }
}
