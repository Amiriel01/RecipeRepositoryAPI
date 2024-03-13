namespace RecipeRepository.API.Models.Domain
{
    public class MealCategory
    {
        public Guid Id { get; set; }

        public string MealUrlHandle { get; set; }

        public string MealName { get; set;}
    }
}
