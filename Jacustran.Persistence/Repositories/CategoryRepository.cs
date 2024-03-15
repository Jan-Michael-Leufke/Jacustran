
using Jacustran.Domain.Entity.Entities;

namespace Jacustran.Persistence.Repositories;

public class CategoryRepository(JacustranDbContext context) : BaseRepository<Category>(context), ICategoryRepository
{

}