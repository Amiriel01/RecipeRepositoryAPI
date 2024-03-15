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

        //GET: {apibaseurl}/api/Allergens
        [HttpGet]
        public async Task<IActionResult> GetAllAllergenCategories()
        {
            //add get to interface and implementation files
            //allergenCategories DM
            var allergenCategories = await allergenCategoryRepository.GetAllAsync();

            //convert DM to DTO, all allergen categories in the list
            var response = new List<AllergenCategoryDTO>();
            foreach (var allergenCategory in allergenCategories)
            {
                response.Add(new AllergenCategoryDTO()
                {
                    Id = allergenCategory.Id,
                    AllergenName = allergenCategory.AllergenName,
                    AllergenUrlHandle = allergenCategory.AllergenUrlHandle,
                });
            }

            return Ok(response);
        }

        //GET: {apibaseurl}/api/Allergens/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetAllergenCategoryById([FromRoute] Guid id)
        {
            var foundAllergenCategory = await allergenCategoryRepository.GetById(id);

            if (foundAllergenCategory == null)
            {
                return NotFound();
            };

            //convert to DTO
            var response = new AllergenCategoryDTO
            {
                Id = foundAllergenCategory.Id,
                AllergenName = foundAllergenCategory.AllergenName,
                AllergenUrlHandle = foundAllergenCategory.AllergenUrlHandle,
            };

            return Ok(response);
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

        //PUT: {apibaseurl}/api/Allergens/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> EditAllergenCategory([FromRoute] Guid id, EditAllergenCategoryRequestDTO request)
        {
            //convert DTO to DM
            var allergenCategory = new AllergenCategory
            {
                Id = id,
                AllergenName = request.AllergenName,
                AllergenUrlHandle = request.AllergenUrlHandle,
            };

            //sent the allergenCategory update to the repository to update the database
            allergenCategory = await allergenCategoryRepository.UpdateAsync(allergenCategory);

            if (allergenCategory != null)
            {
                //convert the DM to DTO
                var response = new AllergenCategoryDTO
                {
                    Id = id,
                    AllergenName = request.AllergenName,
                    AllergenUrlHandle = request.AllergenUrlHandle,
                };

                return Ok(response);
            }

            return NotFound();
        }
    }
}
