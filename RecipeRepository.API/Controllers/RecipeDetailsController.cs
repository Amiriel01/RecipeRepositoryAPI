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
        private readonly IMealCategoryRepository mealCategoryRepository;
        private readonly IAllergenCategoryRepository allergenCategoryRepository;

        public RecipeDetailsController(IRecipeDetailsRepository recipeDetailsRepository, IMealCategoryRepository mealCategoryRepository, IAllergenCategoryRepository allergenCategoryRepository)
        {
            this.recipeDetailsRepository = recipeDetailsRepository;
            this.mealCategoryRepository = mealCategoryRepository;
            this.allergenCategoryRepository = allergenCategoryRepository;
        }

        //GET: {apibaseurl}/api/Recipes
        [HttpGet]
        public async Task<IActionResult> GetAllRecipeDetails()
        {
            //add get to interface and implementation files
            //mealCategories DM
            var recipeDetails = await recipeDetailsRepository.GetAllAsync();

            //convert DM to DTO, all meal categories in the list
            var response = new List<RecipeDetailsDTO>();
            foreach (var recipe in recipeDetails)
            {
                response.Add(new RecipeDetailsDTO()
                {
                    Id = recipe.Id,
                    RecipeName = recipe.RecipeName,
                    RecipeUrlHandle = recipe.RecipeUrlHandle,
                    RecipeShortDescription = recipe.RecipeShortDescription,
                    RecipeContent = recipe.RecipeContent,
                    RecipeImage = recipe.RecipeImage,
                    isVisible = recipe.isVisible,
                    MealCategories = recipe.MealCategories.Select(x => new MealCategoryDTO
                    {
                        Id = x.Id,
                        MealName = x.MealName,
                        MealUrlHandle = x.MealUrlHandle,
                    }).ToList(),
                    AllergenCategories = recipe.AllergenCategories.Select(x => new AllergenCategoryDTO
                    {
                        Id = x.Id,
                        AllergenName = x.AllergenName,
                        AllergenUrlHandle = x.AllergenUrlHandle,
                    }).ToList(),
                });
            }

            return Ok(response);
        }

        //GET: {apibaseurl}/api/Recipes/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetRecipeDetailsById([FromRoute] Guid id)
        {
            var foundRecipeDetails = await recipeDetailsRepository.GetById(id);

            if (foundRecipeDetails == null)
            {
                return NotFound();
            };

            //convert to DTO
            var response = new RecipeDetailsDTO
            {
                Id = foundRecipeDetails.Id,
                RecipeName = foundRecipeDetails.RecipeName,
                RecipeUrlHandle = foundRecipeDetails.RecipeUrlHandle,
                RecipeShortDescription = foundRecipeDetails.RecipeShortDescription,
                RecipeContent = foundRecipeDetails.RecipeContent,
                RecipeImage = foundRecipeDetails.RecipeImage,
                isVisible = foundRecipeDetails.isVisible,
            };

            return Ok(response);
        }

        //POST: {baseapiurl}/api/RecipeDetails
        [HttpPost]
        //create DTO for CreateRecipeDetailsRequestDTO without the DM id in Domain.DTO folder
        //place the DTO as a prop and name it request because the user is requesting the information
        public async Task<IActionResult> CreateRecipeDetails([FromBody] CreateRecipeDetailsRequestDTO request)
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
                MealCategories = new List<MealCategory>(),
                AllergenCategories = new List<AllergenCategory>(),
            };

            //loop through meal category ids
            foreach (var mealCategoryGuid in request.MealCategories)
            {
                var existingMealCategory = await mealCategoryRepository.GetById(mealCategoryGuid);

                if (existingMealCategory != null)
                {
                    recipeDetails.MealCategories.Add(existingMealCategory);
                }
            }

            //loop through allergen category ids
            foreach (var allergenCategoryGuid in request.AllergenCategories)
            {
                var existingAllergenCategory = await allergenCategoryRepository.GetById(allergenCategoryGuid);

                if (existingAllergenCategory != null)
                {
                    recipeDetails.AllergenCategories.Add(existingAllergenCategory);
                }
            }

            //abstracting implementation to the repository
            recipeDetails = await recipeDetailsRepository.CreateAsync(recipeDetails);

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
                MealCategories = recipeDetails.MealCategories.Select(x => new MealCategoryDTO
                {
                    Id = x.Id,
                    MealName = x.MealName,
                    MealUrlHandle = x.MealUrlHandle,
                }).ToList(),
                AllergenCategories = recipeDetails.AllergenCategories.Select(x => new AllergenCategoryDTO
                {
                    Id = x.Id,
                    AllergenName = x.AllergenName,
                    AllergenUrlHandle = x.AllergenUrlHandle,
                }).ToList(),
            };

            return Ok(response);
        }

        //PUT: {apibaseurl}/api/Recipes/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> EditRecipeDetails([FromRoute] Guid id, EditRecipeDetailsRequestDTO request)
        {
            //convert DTO to DM
            var recipeDetails = new RecipeDetails
            {
                Id = id,
                RecipeName = request.RecipeName,
                RecipeUrlHandle = request.RecipeUrlHandle,
                RecipeShortDescription = request.RecipeShortDescription,
                RecipeContent = request.RecipeContent,
                RecipeImage = request.RecipeImage,
                isVisible= request.isVisible,
            };

            //sent the recipeDetails update to the repository to update the database
            recipeDetails = await recipeDetailsRepository.UpdateAsync(recipeDetails);

            if (recipeDetails != null)
            {
                //convert the DM to DTO
                var response = new RecipeDetailsDTO
                {
                    Id = id,
                    RecipeName = request.RecipeName,
                    RecipeUrlHandle = request.RecipeUrlHandle,
                    RecipeShortDescription = request.RecipeShortDescription,
                    RecipeContent = request.RecipeContent,
                    RecipeImage = request.RecipeImage,
                    isVisible = request.isVisible,
                };

                return Ok(response);
            }

            return NotFound();
        }

        //DELETE: {apibaseurl}api/Recipes/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRecipeDetails([FromRoute] Guid id)
        {
            //call repository method
            var recipeDetails = await recipeDetailsRepository.DeleteAsync(id);

            if (recipeDetails != null)
            {
                //convert DM to DTO
                var response = new RecipeDetailsDTO
                {
                    Id = recipeDetails.Id,
                    RecipeName = recipeDetails.RecipeName,
                    RecipeUrlHandle = recipeDetails.RecipeUrlHandle,
                };

                return Ok(response);
            }

            return NotFound();
        }
    }
}
