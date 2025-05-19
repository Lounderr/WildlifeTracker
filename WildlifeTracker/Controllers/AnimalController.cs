using Microsoft.AspNetCore.Mvc;

using WildlifeTracker.Data.Models;
using WildlifeTracker.Models.AnimalDtos;
using WildlifeTracker.Services.Data;

namespace WildlifeTracker.Controllers
{
    public class AnimalController(IAnimalImageService animalImageService)
              : GenericController<Animal, CreateAnimalDto, ReadAnimalDto, UpdateAnimalDto>()
    {
        /// <summary>  
        /// Retrieves all animals with optional filters, pagination, and sorting.  
        /// </summary>  
        /// <param name="page">Page number for pagination.</param>  
        /// <param name="size">Page size for pagination.</param>  
        /// <param name="filters">Optional filters to apply.</param>  
        /// <param name="fields">Optional fields to include in the response.</param>  
        /// <param name="orderBy">Optional sorting criteria.</param>  
        /// <returns>A list of animals.</returns>  
        /// <response code="200">Returns the list of animals.</response>  
        /// <response code="400">If the request parameters are invalid.</response>  
        [HttpGet]
        public override async Task<ActionResult<IEnumerable<object?>>> GetAll(
            [FromQuery] int page,
            [FromQuery] int size,
            [FromQuery] string? filters,
            [FromQuery] string? fields,
            [FromQuery] string? orderBy)
        {
            return await base.GetAll(page, size, filters, fields, orderBy);
        }

        /// <summary>  
        /// Retrieves a specific animal by ID.  
        /// </summary>  
        /// <param name="id">The ID of the animal to retrieve.</param>  
        /// <returns>The animal details.</returns>  
        /// <response code="200">Returns the animal details.</response>  
        /// <response code="404">If the animal is not found.</response>  
        [HttpGet("{id}")]
        public override async Task<ActionResult<ReadAnimalDto>> GetById([FromRoute] int id)
        {
            return await base.GetById(id);
        }

        /// <summary>  
        /// Creates a new animal.  
        /// </summary>  
        /// <param name="item">The animal data to create.</param>  
        /// <returns>The created animal.</returns>  
        /// <response code="201">Returns the created animal.</response>  
        /// <response code="400">If the request body is invalid.</response>  
        [HttpPost]
        public override async Task<ActionResult<ReadAnimalDto>> Create([FromBody] CreateAnimalDto item)
        {
            return await base.Create(item);
        }

        /// <summary>  
        /// Updates an existing animal.  
        /// </summary>  
        /// <param name="id">The ID of the animal to update.</param>  
        /// <param name="item">The updated animal data.</param>  
        /// <returns>No content if the operation is successful.</returns>  
        /// <response code="204">If the update is successful.</response>  
        /// <response code="400">If the request body is invalid.</response>  
        /// <response code="404">If the animal is not found.</response>  
        [HttpPut("{id}")]
        public override async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateAnimalDto item)
        {
            return await base.Update(id, item);
        }

        /// <summary>  
        /// Deletes a specific animal by ID.  
        /// </summary>  
        /// <param name="id">The ID of the animal to delete.</param>  
        /// <returns>No content if the operation is successful.</returns>  
        /// <response code="204">If the deletion is successful.</response>  
        /// <response code="404">If the animal is not found.</response>  
        [HttpDelete("{id}")]
        public override async Task<ActionResult> Delete([FromRoute] int id)
        {
            return await base.Delete(id);
        }

        /// <summary>  
        /// Updates the image of a specific animal.  
        /// </summary>  
        /// <param name="id">The ID of the animal to update the image for.</param>  
        /// <param name="file">The image file to upload.</param>  
        /// <returns>No content if the operation is successful.</returns>  
        /// <response code="204">If the image update is successful.</response>  
        /// <response code="400">If the file is invalid.</response>  
        /// <response code="404">If the animal is not found.</response>  
        [HttpPut("{id}/image")]
        public async Task<ActionResult> UpdateImage([FromRoute] int id, IFormFile file)
        {
            await animalImageService.CreateOrReplaceAsync(id, file);
            return this.NoContent();
        }

        /// <summary>  
        /// Deletes the image of a specific animal.  
        /// </summary>  
        /// <param name="id">The ID of the animal whose image is to be deleted.</param>  
        /// <returns>No content if the operation is successful.</returns>  
        /// <response code="204">If the image deletion is successful.</response>  
        /// <response code="404">If the animal is not found.</response>  
        [HttpDelete("{id}/image")]
        public async Task<ActionResult> DeleteImage([FromRoute] int id)
        {
            await animalImageService.DeleteAsync(id);
            return this.NoContent();
        }
    }
}
