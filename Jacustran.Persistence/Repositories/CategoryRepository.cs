﻿namespace Jacustran.Persistence.Repositories;

public class CategoryRepository(JacustranDbContext context) : BaseRepository<Category, Guid>(context), ICategoryRepository
{

}