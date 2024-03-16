using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeRepository.API.Data;
using RecipeRepository.API.Models.Domain;
using RecipeRepository.API.Models.DTO;
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

        //get all allergenCategories
        public async Task<IEnumerable<AllergenCategory>> GetAllAsync()
        {
            return await dbContext.AllergenCategories.ToListAsync();
        }

        //get a single allergen category
        public async Task<AllergenCategory?> GetById(Guid id)
        {
            return await dbContext.AllergenCategories.FirstOrDefaultAsync(x => x.Id == id);
        }

        //post allergenCategory
        public async Task<AllergenCategory> CreateAsync(AllergenCategory allergenCategory)
        {
            //provide the AllergenCategory to the collection inside ApplicationDbContext
            await dbContext.AllergenCategories.AddAsync(allergenCategory);
            await dbContext.SaveChangesAsync();
            return allergenCategory;
        }

        public async Task<AllergenCategory?> UpdateAsync(AllergenCategory allergenCategory)
        {
            //provide the AllergenCategory update to the collection 
            var foundAllergenCategory = await dbContext.AllergenCategories.FirstOrDefaultAsync(x => x.Id == allergenCategory.Id);

            if (foundAllergenCategory != null)
            {
                //update all of the existing allergen category details to the edited details
                dbContext.Entry(foundAllergenCategory).CurrentValues.SetValues(allergenCategory);
                //save changes to the database
                await dbContext.SaveChangesAsync();
                return allergenCategory;
            }

            return null;
        }

        public async Task<AllergenCategory?> DeleteAsync(Guid id)
        {
            var foundAllergenCategory = await dbContext.AllergenCategories.FirstOrDefaultAsync(x => x.Id == id);

            if (foundAllergenCategory != null)
            {
                dbContext.AllergenCategories.Remove(foundAllergenCategory);
                await dbContext.SaveChangesAsync();
                return foundAllergenCategory;
            }

            return null;
        }
    }
}
