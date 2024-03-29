﻿namespace Jacustran.Domain.Shared;

public class Location(string name) : EntityBase
{
    public Location() : this(string.Empty) { }

    public string Name { get; set; } = name;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }



}
