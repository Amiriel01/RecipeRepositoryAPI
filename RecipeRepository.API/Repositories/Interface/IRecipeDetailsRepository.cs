﻿using RecipeRepository.API.Models.Domain;

namespace RecipeRepository.API.Repositories.Interface
{
    public interface IRecipeDetailsRepository
    {
        //get all recipe details
        Task<IEnumerable<RecipeDetails>> GetAllAsync();

        //get a single recipe
        Task<RecipeDetails?> GetById(Guid id);

        //take a Recipe details and insert it in the database, then return the inserted Recipe details
        Task<RecipeDetails> CreateAsync(RecipeDetails recipe);
    }
}
