using Microsoft.EntityFrameworkCore;
using RecipeRepository.API.Data;
using RecipeRepository.API.Models.Domain;
using RecipeRepository.API.Repositories.Interface;

namespace RecipeRepository.API.Repositories.Implementation
{
    public class MealCategoryRepository : IMealCategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public MealCategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //get a list of MealCategories from the database
        public async Task<IEnumerable<MealCategory>> GetAllAsync()
        {
            return await dbContext.MealCategories.ToListAsync();
        }

        //get a single meal category
        public async Task<MealCategory?> GetById(Guid id)
        {
            return await dbContext.MealCategories.FirstOrDefaultAsync(x => x.Id == id);
        }

        //post a MealCategory to the database
        public async Task<MealCategory> CreateAsync(MealCategory mealCategory)
        {
            //provide the MealCategory to the collection inside ApplicationDbContext
            await dbContext.MealCategories.AddAsync(mealCategory);
            await dbContext.SaveChangesAsync();
            return mealCategory;
        }

        public async Task<MealCategory?> UpdateAsync(MealCategory mealCategory)
        {
            //provide the MealCategory update to the collection 
            var foundMealCategory = await dbContext.MealCategories.FirstOrDefaultAsync(x => x.Id == mealCategory.Id);

            if (foundMealCategory != null)
            {
                //update all of the existing meal category details to the edited details
                dbContext.Entry(foundMealCategory).CurrentValues.SetValues(mealCategory);
                //save changes to the database
                await dbContext.SaveChangesAsync();
                return mealCategory;
            }

            return null;
        }

        public async Task<MealCategory?> DeleteAsync(Guid id)
        {
            var foundMealCategory = await dbContext.MealCategories.FirstOrDefaultAsync(x => x.Id == id);

            if (foundMealCategory != null)
            {
                dbContext.MealCategories.Remove(foundMealCategory);
                await dbContext.SaveChangesAsync();
                return foundMealCategory;
            }

            return null;
        }
    }
}
