using CoffeePattisserie.Service.Abstract;
using CoffeePattisserie.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeePattisserie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeesController : ControllerBase
    {
        private readonly ICoffeeService _coffeeService;
        public CoffeesController(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCoffeeDto addCoffeeDto)
        {
            var response = await _coffeeService.AddAsync(addCoffeeDto);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _coffeeService.GetAllAsync();
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _coffeeService.GetByIdAsync(id);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(EditCoffeeDto editCoffeeDto)
        {
            var response = await _coffeeService.UpdateAsync(editCoffeeDto);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _coffeeService.DeleteAsync(id);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
