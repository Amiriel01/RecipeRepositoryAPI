namespace RecipeRepository.API.Models.Domain
{
    public class RecipeDetails
    {
        public Guid Id { get; set; }

        public string RecipeUrlHandle { get; set; }

        public string RecipeName { get; set; }

        public string RecipeShortDescription { get; set;}

        public string RecipeContent { get; set; }

        public string RecipeImage { get; set;}

        public bool isVisible { get; set; }

        //recipe details can have many categories
        public ICollection<MealCategory> MealCategories { get; set; }

        public ICollection<AllergenCategory> AllergenCategories { get; set;}
    }
}
