using Jacustran.Domain.Statics;
using Jacustran.Domain.Shared;
using System.Security.Cryptography;

namespace Jacustran.Domain.Entities;

public class City(string name) : Town(name)
{
    public City() : this(string.Empty) { }

    public bool IsImportantCity { get; set; }


}
