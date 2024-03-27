namespace RecipeRepository.API.Models.DTO
{
    public class CreateRecipeDetailsRequestDTO
    {
        public string RecipeUrlHandle { get; set; }

        public string RecipeName { get; set; }

        public string RecipeShortDescription { get; set; }

        public string RecipeContent { get; set; }

        public string RecipeImage { get; set; }

        public bool isVisible { get; set; }

        //accept ids from categories
        public Guid[] MealCategories { get; set; }

        public Guid[] AllergenCategories { get; set; }
    }
}
