namespace RecipeRepository.API.Models.Domain
{
    public class AllergenCategory
    {
        public Guid Id { get; set; }

        public string AllergenUrlHandle { get; set; }

        public string AllergenName { get; set; }

        //represents the relation between recipe details and allergen categories
        //an allergen category can have many recipes
        public ICollection<RecipeDetails> RecipeDetails { get; set; }
    }
}
