namespace RecipeRepository.API.Models.Domain
{
    public class MealCategory
    {
        public Guid Id { get; set; }

        public string MealUrlHandle { get; set; }

        public string MealName { get; set;}

        //represents the relation between recipe details and meal categories
        //a meal category can have many recipes
        public ICollection<RecipeDetails> RecipeDetails { get; set; }
    }
}
