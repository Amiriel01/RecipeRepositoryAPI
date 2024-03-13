using RecipeRepository.API.Models.Domain;

namespace RecipeRepository.API.Repositories.Interface
{
    public interface IRecipeDetailsRepository
    {
        //take a Recipe details and insert it in the database, then return the inserted Recipe details
        Task<RecipeDetails> CreateAsync(RecipeDetails recipe);
    }
}
