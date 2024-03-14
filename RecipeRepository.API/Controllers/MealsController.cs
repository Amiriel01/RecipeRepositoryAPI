using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeRepository.API.Data;
using RecipeRepository.API.Models.Domain;
using RecipeRepository.API.Models.DTO;
using RecipeRepository.API.Repositories.Implementation;
using RecipeRepository.API.Repositories.Interface;

namespace RecipeRepository.API.Controllers
{
    //https://localhost:7184/api/meals
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly IMealCategoryRepository mealCategoryRepository;

        //inject interface in controller
        public MealsController(IMealCategoryRepository mealCategoryRepository)
        {
            this.mealCategoryRepository = mealCategoryRepository;
        }

        //GET: {apibaseurl}/api/Meals
        [HttpGet]
        public async Task<IActionResult> GetAllMealCategories()
        {
            //add get to interface and implementation files
            //mealCategories DM
            var mealCategories = await mealCategoryRepository.GetAllAsync();

            //convert DM to DTO, all meal categories in the list
            var response = new List<MealCategoryDTO>();
            foreach (var mealCategory in mealCategories)
            {
                response.Add(new MealCategoryDTO()
                {
                    Id = mealCategory.Id,
                    MealName = mealCategory.MealName,
                    MealUrlHandle = mealCategory.MealUrlHandle,
                });
            }   

            return Ok(response);
        }

        //POST: {apibaseurl}/api/Meals
        [HttpPost]
        //create DTO for CreateMealDTO without the DM id in Domain.DTO folder
        //place the DTO as a prop and name it request because the user is requesting the information
        public async Task<IActionResult> CreateMealCategory(CreateMealCategoryRequestDTO request)
        {
            //covert DTO to DM
            var mealCategory = new MealCategory
            {
                //skip adding id because Entity Framework Core will do that when the form is submitted
                MealName = request.MealName,
                MealUrlHandle = request.MealUrlHandle,
            };

            //abstracting implementation to the repository
            await mealCategoryRepository.CreateAsync(mealCategory);

            //convert DM to DTO
            var response = new MealCategoryDTO
            {
                Id = mealCategory.Id,
                MealName = mealCategory.MealName,
                MealUrlHandle = mealCategory.MealUrlHandle,
            };

            return Ok(response);
        }
    }
}
