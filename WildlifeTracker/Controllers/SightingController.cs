using Microsoft.AspNetCore.Mvc;

using WildlifeTracker.Data.Models;
using WildlifeTracker.Helpers.Extensions;
using WildlifeTracker.Models.SightingDtos;

namespace WildlifeTracker.Controllers
{
    public class SightingController()
              : GenericController<Sighting, CreateSightingDto, ReadSightingDto, UpdateSightingDto>()
    {
        /// <summary>    
        /// Retrieves all sightings with optional pagination, filtering, and sorting.    
        /// </summary>    
        /// <param name="page">The page number for pagination.</param>    
        /// <param name="size">The number of items per page.</param>    
        /// <param name="filters">Optional filters to apply.</param>    
        /// <param name="fields">Optional fields to include in the response.</param>    
        /// <param name="orderBy">Optional sorting criteria.</param>    
        /// <response code="200">Returns the list of sightings.</response>    
        /// <response code="400">If the request parameters are invalid.</response>    
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        /// Retrieves a specific sighting by its ID.    
        /// </summary>    
        /// <param name="id">The ID of the sighting to retrieve.</param>    
        /// <response code="200">Returns the requested sighting.</response>    
        /// <response code="404">If the sighting is not found.</response>    
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override async Task<ActionResult<ReadSightingDto>> GetById([FromRoute] int id)
        {
            return await base.GetById(id);
        }

        /// <summary>    
        /// Creates a new sighting.    
        /// </summary>    
        /// <param name="item">The sighting data to create.</param>    
        /// <response code="201">Returns the created sighting.</response>    
        /// <response code="400">If the request body is invalid.</response>    
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public override Task<ActionResult<ReadSightingDto>> Create([FromBody] CreateSightingDto item)
        {
            item.ObserverId = this.User.GetUserId();
            return base.Create(item);
        }

        /// <summary>    
        /// Updates an existing sighting.    
        /// </summary>    
        /// <param name="id">The ID of the sighting to update.</param>    
        /// <param name="item">The updated sighting data.</param>    
        /// <response code="200">Returns the updated sighting.</response>    
        /// <response code="400">If the request body is invalid.</response>    
        /// <response code="404">If the sighting is not found.</response>    
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateSightingDto item)
        {
            item.ObserverId = this.User.GetUserId();
            return base.Update(id, item);
        }

        /// <summary>    
        /// Deletes a specific sighting by its ID.    
        /// </summary>    
        /// <param name="id">The ID of the sighting to delete.</param>    
        /// <response code="200">If the sighting was successfully deleted.</response>    
        /// <response code="404">If the sighting is not found.</response>    
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override async Task<ActionResult> Delete([FromRoute] int id)
        {
            return await base.Delete(id);
        }
    }
}
