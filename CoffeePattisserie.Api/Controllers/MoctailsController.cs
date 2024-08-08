using CoffeePattisserie.Service.Abstract;
using CoffeePattisserie.Shared.Dtos;
using CoffeePattisserie.Shared.Helpers.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoffeePattisserie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoctailsController : ControllerBase
    {
        private readonly IMoctailService _moctailService;
        private readonly IImageHelper _imageHelper;

        public MoctailsController(IMoctailService moctailService, IImageHelper imageHelper)
        {
            _moctailService = moctailService;
            _imageHelper = imageHelper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddMoctailDto addMoctailDto)
        {
            var response = await _moctailService.AddAsync(addMoctailDto);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _moctailService.GetAllAsync();
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _moctailService.GetByIdAsync(id);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("homemoctails")]
        public async Task<IActionResult> GetHomeMoctails()
        {
            var response = await _moctailService.GetHomeMoctailsAsync();
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }

        [HttpPut]
        public async Task<IActionResult> Update(EditMoctailDto editMoctailDto)
        {
            var response = await _moctailService.UpdateAsync(editMoctailDto);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _moctailService.DeleteAsync(id);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("bycategory/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var response = await _moctailService.GetMoctailsByCategoryIdAsync(categoryId);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("active/{isActive}")]
        public async Task<IActionResult> GetActiveMoctails(bool isActive)
        {
            var response = await _moctailService.GetActiveMoctailsAsync(isActive);
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }

        [HttpPost("addimage")]
        public async Task<IActionResult> ImageUpload(IFormFile file)
        {
            var response = await _imageHelper.Upload(file, "moctails");
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
