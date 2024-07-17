using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess.Models.ViewModel.CollectionViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.Commons;
using Microsoft.AspNetCore.Mvc;

namespace JewelleryShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionService _collectionService;


        public CollectionController(ICollectionService collectionService)
        {
            _collectionService = collectionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCollection()
        {
            var collections = await _collectionService.GetAllCollection();
            return Ok(collections);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCollectionById(string id)
        {
            var collection = await _collectionService.GetCollectionById(id);
            if (collection == null)
            {
                var response = APIResponse<CollectionCommonDTO>
                    .ErrorResponse(new List<string> { "No collection found with the provided ID." });
                return NotFound(response);
            }
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> AddCollection(CollectionInputDTO collection)
        {
            var newCollection = await _collectionService.AddCollection(collection);
            return CreatedAtAction(nameof(GetCollectionById), new { id = newCollection.Id }, newCollection);
        }

        [HttpPut("Collection/{id}")]
        public async Task<IActionResult> UpdateCollectionAsync(string id, CollectionInputDTO collectionDTO)
        {
            try
            {
                var updatedCollection = await _collectionService.UpdateCollectionAsync(id, collectionDTO);
                return Ok(updatedCollection);
            }
            catch (Exception ex)
            {
                var response = APIResponse<CollectionInputDTO>
                    .ErrorResponse(new List<string> { ex.Message });
                return BadRequest(response);
            }
        }

        [HttpDelete("Collection/{id}")]
        public async Task<IActionResult> DeleteCollectionAsync(string id)
        {
            try
            {
                await _collectionService.DeleteCollectionAsync(id);
                var response = APIResponse<string>.SuccessResponse(id, "Collection deleted successfully");
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                var response = APIResponse<string>
                    .ErrorResponse(new List<string> { ex.Message });
                return NotFound(response);
            }
        }
    }
}
