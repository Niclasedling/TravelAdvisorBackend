using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Interfaces;
using TravelAdvisor.Infrastructure.Models;

namespace TravelAdvisor.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AttractionController : Controller
    {
        private readonly ILogger<AttractionController> _logger;
        public readonly IAttractionService _attractionService;

        public AttractionController(IAttractionService attractionService, ILogger<AttractionController> logger)
        {
            _attractionService = attractionService ?? throw new ArgumentNullException(nameof(attractionService));
            _logger = logger;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _attractionService.GetById(id);
            if (item != null)
            {
                return Ok(item);
            }

            return BadRequest($"{nameof(GetById)} returned null."); // Tillfällig - fixa sen
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var item = await _attractionService.GetAll();
            if (item != null)
            {
                return Ok(item);
            }
            return BadRequest($"{nameof(GetAll)} returned null."); // Tillfällig - fixa sen
        }


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var item = await _attractionService.GetList();
            if (item != null)
            {
                return Ok(item);
            }

            return BadRequest($"{nameof(GetList)} returned null."); // Tillfällig - fixa sen
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _attractionService.Delete(id))
            {
                return Ok();
            }

            return BadRequest($"{nameof(Delete)} returned false."); // Tillfällig - fixa sen
        }

        //[HttpPost("Create")]
        //public async Task<IActionResult> Create(AttractionCreateDto newAttraction)
        //{
        //    var item = await _attractionService.Create(newAttraction);

        //    return Ok(item);

        //    /*return BadRequest($"{nameof(Create)} returned null.");*/ // Tillfällig - fixa sen
        //}

        [HttpPut("Update")]
        public async Task<IActionResult> Update(AttractionUpdateDto updateAttraction)
        {
            var success = await _attractionService.Update(updateAttraction);

            if (success)
            {
                return Ok();
            }

            return BadRequest($"{nameof(Update)} returned null."); // Tillfällig - fixa sen
        }
    }
}
