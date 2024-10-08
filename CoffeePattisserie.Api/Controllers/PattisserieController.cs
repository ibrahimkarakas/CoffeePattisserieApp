using System.Text.Json;
using CoffeePattisserie.Service.Abstract;
using CoffeePattisserie.Shared.Dtos;
using CoffeePattisserie.Shared.Helpers.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeePattisserie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PattisserieController : ControllerBase
    {
        private readonly IPattisserieService _pattisserieService;
        private readonly IImageHelper _imageHelper;

        public PattisserieController(IPattisserieService pattisserieService, IImageHelper imageHelper)
        {
            _pattisserieService = pattisserieService;
            _imageHelper = imageHelper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddPattisserieDto addPattisserieDto)
        {
            var response = await _pattisserieService.AddAsync(addPattisserieDto);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _pattisserieService.GetAllAsync();
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("homepattisseries")]
        public async Task<IActionResult> GetHomePattisseries()
        {
            var response = await _pattisserieService.GetHomePattisserieAsync();
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _pattisserieService.GetByIdAsync(id);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(EditPattisserieDto editPattisserieDto)
        {
            var response = await _pattisserieService.UpdateAsync(editPattisserieDto);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _pattisserieService.DeleteAsync(id);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("bycategory/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var response = await _pattisserieService.GetPattisserieByCategoryIdAsync(categoryId);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("active/{isActive}")]
        public async Task<IActionResult> GetActivePattisseries(bool isActive)
        {
            var response = await _pattisserieService.GetActivePattisserieAsync(isActive);
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }

        [HttpPost("addimage")]
        public async Task<IActionResult> ImageUpload(IFormFile file)
        {
            var response = await _imageHelper.Upload(file, "pattisserie");
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
