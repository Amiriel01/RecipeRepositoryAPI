using RecipeRepository.API.Models.Domain;

namespace RecipeRepository.API.Repositories.Interface
{
    public interface IMealCategoryRepository
    {
        //take a MealCategory and insert it in the database, then return the inserted MealCategory
        Task<MealCategory> CreateAsync(MealCategory mealCategory);
    }
}
