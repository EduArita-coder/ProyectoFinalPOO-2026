using Microsoft.AspNetCore.Mvc;
using StreetStatusAPI.Entities;
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

        // GET api/street
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var streets = await _streetService.GetAllAsync();
            return Ok(streets);
        }

        // GET api/street/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var street = await _streetService.GetByIdAsync(id);
            if (street is null)
                return NotFound(new { message = $"Calle con id {id} no encontrada." });

            return Ok(street);
        }

        // POST api/street
        [HttpPost]
        public async Task<IActionResult> Create(Street street)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _streetService.CreateAsync(street);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}
