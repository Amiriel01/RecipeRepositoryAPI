using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeRepository.API.Models.Domain;
using RecipeRepository.API.Models.DTO;
using RecipeRepository.API.Repositories.Implementation;
using RecipeRepository.API.Repositories.Interface;

namespace RecipeRepository.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeDetailsController : ControllerBase
    {
        private readonly IRecipeDetailsRepository recipeDetailsRepository;

        public RecipeDetailsController(IRecipeDetailsRepository recipeDetailsRepository)
        {
            this.recipeDetailsRepository = recipeDetailsRepository;
        }

        //POST: {baseapiurl}/api/Meals
        [HttpPost]
        //create DTO for CreateRecipeDetailsRequestDTO without the DM id in Domain.DTO folder
        //place the DTO as a prop and name it request because the user is requesting the information
        public async Task<IActionResult> CreateRecipeDetails(CreateRecipeDetailsRequestDTO request)
        {
            //covert DTO to DM
            var recipeDetails = new RecipeDetails
            {
                //skip adding id because Entity Framework Core will do that when the form is submitted
                RecipeName = request.RecipeName,
                RecipeUrlHandle = request.RecipeUrlHandle,
                RecipeShortDescription = request.RecipeShortDescription,
                RecipeContent = request.RecipeContent,
                RecipeImage = request.RecipeImage,
                isVisible = request.isVisible,
            };

            //abstracting implementation to the repository
            await recipeDetailsRepository.CreateAsync(recipeDetails);

            //convert DM to DTO
            var response = new RecipeDetailsDTO
            {
                Id = recipeDetails.Id,
                RecipeName = recipeDetails.RecipeName,
                RecipeUrlHandle = recipeDetails.RecipeUrlHandle,
                RecipeShortDescription = recipeDetails.RecipeShortDescription,
                RecipeContent = recipeDetails.RecipeContent,
                RecipeImage = recipeDetails.RecipeImage,
                isVisible = recipeDetails.isVisible,
            };

            return Ok(response);
        }
    }
}
