using Microsoft.EntityFrameworkCore;
using RecipeRepository.API.Data;
using RecipeRepository.API.Models.Domain;
using RecipeRepository.API.Repositories.Interface;

namespace RecipeRepository.API.Repositories.Implementation
{
    public class AllergenCategoryRepository : IAllergenCategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public AllergenCategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<AllergenCategory> CreateAsync(AllergenCategory allergenCategory)
        {
            //provide the AllergenCategory to the collection inside ApplicationDbContext
            await dbContext.AllergenCategories.AddAsync(allergenCategory);
            await dbContext.SaveChangesAsync();
            return allergenCategory;
        }
    }
}
