using RecipeRepository.API.Models.Domain;

namespace RecipeRepository.API.Repositories.Interface
{
    public interface IMealCategoryRepository
    {
        //use MealCategory to get a list of all categories and return the list
        Task<IEnumerable<MealCategory>> GetAllAsync();

        //get a single meal category
        Task<MealCategory?> GetById(Guid id);

        //take a MealCategory and insert it in the database, then return the inserted MealCategory
        Task<MealCategory> CreateAsync(MealCategory mealCategory);
        
    }
}
