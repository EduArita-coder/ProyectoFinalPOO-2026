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
        public async Task<IActionResult> GetById(int id)
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
    }
}
