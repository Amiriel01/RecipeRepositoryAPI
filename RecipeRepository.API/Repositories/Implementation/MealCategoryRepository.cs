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

        //post a MealCategory to the database
        public async Task<MealCategory> CreateAsync(MealCategory mealCategory)
        {
            //provide the MealCategory to the collection inside ApplicationDbContext
            await dbContext.MealCategories.AddAsync(mealCategory);
            await dbContext.SaveChangesAsync();
            return mealCategory;
        }

       
    }
}
