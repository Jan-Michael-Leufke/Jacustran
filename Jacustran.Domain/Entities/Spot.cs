﻿using Jacustran.Domain.Enumerations;
using Jacustran.Domain.Shared;

namespace Jacustran.Domain.Entities;

public class Spot(string name) : Location(name)
{
	public Spot() : this(string.Empty) { }

	public StarRating Rating { get; set; }

	public Town? Town { get; set; }	
	public Guid TownId { get; set; }
	
}
