namespace RecipeRepository.API.Models.DTO
{
    public class RecipeDetailsDTO
    {
        public Guid Id { get; set; }

        public string RecipeUrlHandle { get; set; }

        public string RecipeName { get; set; }

        public string RecipeShortDescription { get; set; }

        public string RecipeContent { get; set; }

        public string RecipeImage { get; set; }

        public bool isVisible { get; set; }

        public List<MealCategoryDTO> MealCategories { get; set; } = new List<MealCategoryDTO>();

        public List<AllergenCategoryDTO> AllergenCategories { get; set; } = new List<AllergenCategoryDTO>();
    }
}
