using Microsoft.AspNetCore.Mvc;
using StreetStatusAPI.Dtos.Streets;
using StreetStatusAPI.Services;

namespace StreetStatusAPI.Controllers
{
    [ApiController]
    [Route("api/street")]
    public class StreetController : ControllerBase
    {
        private readonly IStreetService _streetService;

        public StreetController(IStreetService streetService)
        {
            _streetService = streetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _streetService.GetAllAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _streetService.GetByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StreetCreateDto dto)
        {
            var result = await _streetService.CreateAsync(dto);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id,StreetEditDto dto)
            {
                var result = await _streetService.EditAsync(id, dto);
                return StatusCode(result.StatusCode, result);
            }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var result = await _streetService.DeleteAsync(id);
            return StatusCode(result.StatusCode,result);
        }
    }
}
