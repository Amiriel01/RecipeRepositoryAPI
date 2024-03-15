using RecipeRepository.API.Models.Domain;

namespace RecipeRepository.API.Repositories.Interface
{
    public interface IAllergenCategoryRepository
    {
        //take a AllergenCategory and insert it in the database, then return the inserted AllergenCategory
        Task<IEnumerable<AllergenCategory>> GetAllAsync();

        //get a single allergen category
        Task<AllergenCategory?> GetById(Guid id);

        //take a AllergenCategory and insert it in the database, then return the inserted AllergenCategory
        Task<AllergenCategory> CreateAsync(AllergenCategory allergenCategory);

        //takes the AllergenCategory DM that needs to be updated and will return updated object or null
        Task<AllergenCategory?> UpdateAsync(AllergenCategory allergenCategory);
    }
}
