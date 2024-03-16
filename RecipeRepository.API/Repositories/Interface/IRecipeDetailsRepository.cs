using RecipeRepository.API.Models.Domain;

namespace RecipeRepository.API.Repositories.Interface
{
    public interface IRecipeDetailsRepository
    {
        //get all recipe details
        Task<IEnumerable<RecipeDetails>> GetAllAsync();

        //get a single recipe
        Task<RecipeDetails?> GetById(Guid id);

        //take a Recipe details and insert it in the database, then return the inserted Recipe details
        Task<RecipeDetails> CreateAsync(RecipeDetails recipe);

        //takes the RecipeDetails DM that needs to be updated and will return updated object or null
        Task<RecipeDetails?> UpdateAsync(RecipeDetails recipeDetails);

        //takes the RecipeDetails DM that needs to be deleted and will delete it or return null
        Task<RecipeDetails?> DeleteAsync(Guid id);
    }
}
