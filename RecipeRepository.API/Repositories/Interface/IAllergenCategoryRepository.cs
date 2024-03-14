using RecipeRepository.API.Models.Domain;

namespace RecipeRepository.API.Repositories.Interface
{
    public interface IAllergenCategoryRepository
    {
        //take a AllergenCategory and insert it in the database, then return the inserted AllergenCategory
        Task<IEnumerable<AllergenCategory>> GetAllAsync();

        //take a AllergenCategory and insert it in the database, then return the inserted AllergenCategory
        Task<AllergenCategory> CreateAsync(AllergenCategory allergenCategory);
    }
}
