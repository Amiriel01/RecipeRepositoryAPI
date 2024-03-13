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
    public class AllergenController : ControllerBase
    {
        private readonly IAllergenCategoryRepository allergenCategoryRepository;

        public AllergenController(IAllergenCategoryRepository allergenCategoryRepository)
        {
            this.allergenCategoryRepository = allergenCategoryRepository;
        }

        //POST: {baseapiurl}/api/Allergen
        [HttpPost]
        //create DTO for CreateAllergenDTO without the DM id in Domain.DTO folder
        //place the DTO as a prop and name it request because the user is requesting the information
        public async Task<IActionResult> CreateAllergenCategory(CreateAllergenCategoryRequestDTO request)
        {
            //covert DTO to DM
            var allergenCategory = new AllergenCategory
            {
                //skip adding id because Entity Framework Core will do that when the form is submitted
                AllergenName = request.AllergenName,
                AllergenUrlHandle = request.AllergenUrlHandle,
            };

            //abstracting implementation to the repository
            await allergenCategoryRepository.CreateAsync(allergenCategory);

            //convert DM to DTO
            var response = new AllergenCategoryDTO
            {
                Id = allergenCategory.Id,
                AllergenName = allergenCategory.AllergenName,
                AllergenUrlHandle = allergenCategory.AllergenUrlHandle,
            };

            return Ok(response);
        }
    }
}
