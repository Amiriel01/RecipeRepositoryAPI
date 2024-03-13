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

        public async Task<RecipeDetails> CreateAsync(RecipeDetails recipeDetails)
        {
            //provide the Recipe details to the collection inside ApplicationDbContext
            await dbContext.RecipeDetails.AddAsync(recipeDetails);
            await dbContext.SaveChangesAsync();
            return recipeDetails;
        }
    }
}
