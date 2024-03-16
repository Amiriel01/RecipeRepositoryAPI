using Microsoft.EntityFrameworkCore;
using RecipeRepository.API.Data;
using RecipeRepository.API.Models.Domain;
using RecipeRepository.API.Repositories.Interface;

namespace RecipeRepository.API.Repositories.Implementation
{
    public class RecipeDetailsRepository: IRecipeDetailsRepository
    {
        private readonly ApplicationDbContext dbContext;

        public RecipeDetailsRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //get a list of the recipes with details
        public async Task<IEnumerable<RecipeDetails>> GetAllAsync()
        {
            return await dbContext.RecipeDetails.ToListAsync();
        }

        //get a single recipes with details if found or return null if not found
        public async Task<RecipeDetails?> GetById(Guid id)
        {
            return await dbContext.RecipeDetails.FirstOrDefaultAsync(x => x.Id == id);
        }

        //post new recipe
        public async Task<RecipeDetails> CreateAsync(RecipeDetails recipeDetails)
        {
            //provide the Recipe details to the collection inside ApplicationDbContext
            await dbContext.RecipeDetails.AddAsync(recipeDetails);
            await dbContext.SaveChangesAsync();
            return recipeDetails;
        }

        public async Task<RecipeDetails?> UpdateAsync(RecipeDetails recipeDetails)
        {
            //provide the RecipeDetails update to the collection 
            var foundReipeDetails = await dbContext.RecipeDetails.FirstOrDefaultAsync(x => x.Id == recipeDetails.Id);

            if (foundReipeDetails != null)
            {
                //update all of the existing recipe details to the edited recipe details
                dbContext.Entry(foundReipeDetails).CurrentValues.SetValues(recipeDetails);
                //save changes to the database
                await dbContext.SaveChangesAsync();
                return recipeDetails;
            }

            return null;
        }

        public async Task<RecipeDetails?> DeleteAsync(Guid id)
        {
            var foundRecipeDetails = await dbContext.RecipeDetails.FirstOrDefaultAsync(x => x.Id == id);

            if (foundRecipeDetails != null)
            {
                dbContext.RecipeDetails.Remove(foundRecipeDetails);
                await dbContext.SaveChangesAsync();
                return foundRecipeDetails;
            }

            return null;
        }
    }
}
