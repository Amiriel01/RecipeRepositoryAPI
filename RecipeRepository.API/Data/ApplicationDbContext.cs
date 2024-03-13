using Microsoft.EntityFrameworkCore;
using RecipeRepository.API.Models.Domain;

namespace RecipeRepository.API.Data
{
    //import DbContext form Microsoft.EntityFrameworkCore
    public class ApplicationDbContext : DbContext
    {
        //create construction using options
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //create properties for the class
        //Dbset, the name of the domain model, the name of the property
        //Dbset class represents the collection of entities from each domain
        public DbSet<AllergenCategory> AllergenCategories { get; set; }
        public DbSet<MealCategory> MealCategories { get; set; }
        public DbSet<RecipeDetails> RecipeDetails { get; set; }
    }
}
