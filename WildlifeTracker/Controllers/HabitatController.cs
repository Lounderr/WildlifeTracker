using Microsoft.AspNetCore.Mvc;

using WildlifeTracker.Data.Models;
using WildlifeTracker.Models.HabitatDtos;

namespace WildlifeTracker.Controllers
{
    public class HabitatController : GenericController<Habitat, CreateHabitatDto, ReadHabitatDto, UpdateHabitatDto>
    {
        /// <summary>  
        /// Retrieves all habitats with optional filtering, paging, and sorting.  
        /// </summary>  
        /// <param name="page">Page number.</param>  
        /// <param name="size">Page size.</param>  
        /// <param name="filters">Filters to apply.</param>  
        /// <param name="fields">Fields to include in the response.</param>  
        /// <param name="orderBy">Sorting order.</param>  
        /// <returns>A list of habitats.</returns>  
        /// <response code="200">Returns the list of habitats.</response>  
        /// <response code="400">If the request parameters are invalid.</response>  
        [HttpGet]
        public override async Task<ActionResult<IEnumerable<object?>>> GetAll([FromQuery] int page, [FromQuery] int size, [FromQuery] string? filters, [FromQuery] string? fields, [FromQuery] string? orderBy)
        {
            return await base.GetAll(page, size, filters, fields, orderBy);
        }

        /// <summary>  
        /// Retrieves a habitat by its ID.  
        /// </summary>  
        /// <param name="id">The ID of the habitat.</param>  
        /// <returns>The habitat with the specified ID.</returns>  
        /// <response code="200">Returns the habitat with the specified ID.</response>  
        /// <response code="404">If the habitat is not found.</response>  
        [HttpGet("{id}")]
        public override async Task<ActionResult<ReadHabitatDto>> GetById([FromRoute] int id)
        {
            return await base.GetById(id);
        }

        /// <summary>  
        /// Creates a new habitat.  
        /// </summary>  
        /// <param name="item">The habitat to create.</param>  
        /// <returns>The created habitat.</returns>  
        /// <response code="201">Returns the newly created habitat.</response>  
        /// <response code="400">If the habitat data is invalid.</response>  
        [HttpPost]
        public override async Task<ActionResult<ReadHabitatDto>> Create([FromBody] CreateHabitatDto item)
        {
            return await base.Create(item);
        }

        /// <summary>  
        /// Updates an existing habitat.  
        /// </summary>  
        /// <param name="id">The ID of the habitat to update.</param>  
        /// <param name="item">The updated habitat data.</param>  
        /// <returns>The updated habitat.</returns>  
        /// <response code="204">Indicates the habitat was successfully updated.</response>  
        /// <response code="400">If the habitat data is invalid.</response>  
        /// <response code="404">If the habitat is not found.</response>  
        [HttpPut("{id}")]
        public override async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateHabitatDto item)
        {
            return await base.Update(id, item);
        }

        /// <summary>  
        /// Deletes a habitat by its ID.  
        /// </summary>  
        /// <param name="id">The ID of the habitat to delete.</param>  
        /// <returns>A confirmation of the deletion.</returns>  
        /// <response code="204">Indicates the habitat was successfully deleted.</response>  
        /// <response code="404">If the habitat is not found.</response>  
        [HttpDelete("{id}")]
        public override async Task<ActionResult> Delete([FromRoute] int id)
        {
            return await base.Delete(id);
        }
    }
}
