using ByteSizeLib;
using JewelleryShop.Business.Service;
using JewelleryShop.Business.Service.Interface;
using JewelleryShop.DataAccess.Models;
using JewelleryShop.DataAccess.Models.ViewModel.CollectionViewModel;
using JewelleryShop.DataAccess.Models.ViewModel.Commons;
using JewelleryShop.DataAccess.Models.ViewModel.ItemImageViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JewelleryShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemImageController: ControllerBase 
    {
        private readonly IItemImageService _itemImageService;
        private readonly IImgBBService _ImgBBService;
        private readonly IConfiguration _configuration;

        public ItemImageController(IItemImageService itemImageService, IImgBBService imgBBService, IConfiguration configuration)
        {
            _itemImageService = itemImageService;
            _ImgBBService = imgBBService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItemImages()
        {
            var imgs = await _itemImageService.GetAllItemImage();
            return Ok(imgs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemImagesById(string id)
        {
            try
            {
                var img = await _itemImageService.GetItemImageById(id);
                if (img == null)
                {
                    var response = APIResponse<CollectionCommonDTO>
                        .ErrorResponse(new List<string> { "No image found with the provided ID." });
                    return NotFound(response);
                }
                return Ok(img);
            }
            catch (Exception ex)
            {
                var response = APIResponse<string>
                    .ErrorResponse(new List<string> { ex.Message });
                return BadRequest(response);
            }
        }

        [HttpGet("ItemImages/{itemID}")]
        public async Task<IActionResult> GetItemImagesByItemID(string itemID, int? count = null)
        {
            try
            {
                var imgs = await _itemImageService.GetItemImagesByItemID(itemID, count);
                if (imgs.IsNullOrEmpty())
                {
                    var response = APIResponse<string>
                        .ErrorResponse(new List<string> { "No items found with the provided ID." });
                    return NotFound(response);
                }
                return Ok(
                    APIResponse<List<ItemImageCommonDTO>>
                        .SuccessResponse(data: imgs, "Successfully fetched item images.")
                    );
            }
            catch (Exception ex)
            {
                var response = APIResponse<string>
                    .ErrorResponse(new List<string> { ex.Message });
                return BadRequest(response);
            }
        }

        [HttpPost("upload")]
        public async Task<ActionResult> UploadImage(IFormFile file, [FromForm] string? itemId)
        {
            try
            {
                var maxFileSize = _configuration.GetValue<long>("ImgBBApiSettings:MaxFileSize");
                //var _maxFileSizez = ByteSize.FromBytes(maxFileSize);
                //Console.WriteLine($"{maxFileSize} {_maxFileSizez}");

                if (file == null || file.Length == 0) // Just incase
                {
                    throw new Exception("No file uploaded.");
                }
                if (file.Length > maxFileSize)
                {
                    var _maxFileSize = ByteSize.FromBytes(maxFileSize);
                    throw new Exception($"File size exceeds the maximum limit of {_maxFileSize}.");
                }

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    var imageBytes = memoryStream.ToArray();
                    var uploadResult = await _ImgBBService.UploadImageAsync(imageBytes);

                    var itemImage = new ItemImageInputDTO
                    {
                        ItemId = itemId,
                        ImageUrl = uploadResult.Data.Url,
                        ThumbnailUrl = uploadResult.Data.Thumb.Url.ToString(),
                    };

                    var newImgItem = await _itemImageService.AddItemImage(itemImage);
                    return Ok(
                        APIResponse<ItemImageCommonDTO>
                            .SuccessResponse(data: newImgItem, "Successfully uploaded item image.")
                        );
                }
            }
            catch (Exception ex)
            {
                var response = APIResponse<string>
                    .ErrorResponse(new List<string> { ex.Message });
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddItemImage(ItemImageInputDTO img_items)
        {
            try
            {
                var newImgItems = await _itemImageService.AddItemImage(img_items);
                return Ok(
                    APIResponse<ItemImageCommonDTO>
                        .SuccessResponse(data: newImgItems, "Successfully added item image.")
                    );
            }
            catch (Exception ex)
            {
                var response = APIResponse<string>
                    .ErrorResponse(new List<string> { ex.Message });
                return BadRequest(response);
            }
        }

        [HttpPut("ItemImages/{id}")]
        public async Task<IActionResult> UpdateItemImagesAsync(string id, ItemImageInputDTO imgDTO)
        {
            try
            {
                var updatedImages = await _itemImageService.UpdateItemImageAsync(id, imgDTO);
                return Ok(
                    APIResponse<ItemImageCommonDTO>
                        .SuccessResponse(data: updatedImages, "Successfully updated item image.")
                    );
            }
            catch (Exception ex)
            {
                var response = APIResponse<string>
                    .ErrorResponse(new List<string> { ex.Message });
                return BadRequest(response);
            }
        }

        [HttpDelete("ItemImages/{id}")]
        public async Task<IActionResult> DeleteItemImagesAsync(string id)
        {
            try
            {
                await _itemImageService.DeleteItemImageAsync(id);
                var response = APIResponse<string>.SuccessResponse(id, "Items deleted successfully");
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
