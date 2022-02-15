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
    public class ThumbInteractionController : Controller
    {
        private readonly ILogger<ThumbInteractionController> _logger;
        public readonly IThumbInteractionService _thumbInteractionService;

        public ThumbInteractionController(IThumbInteractionService thumbInteractionService, ILogger<ThumbInteractionController> logger)
        {
            _thumbInteractionService = thumbInteractionService ?? throw new ArgumentNullException(nameof(thumbInteractionService));
            _logger = logger;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _thumbInteractionService.GetById(id);
            if (item != null)
            {
                return Ok(item);
            }

            return BadRequest($"{nameof(GetById)} returned null.");
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var item = await _thumbInteractionService.GetAll();
            if (item != null)
            {
                return Ok(item);
            }
            return BadRequest($"{nameof(GetAll)} returned null.");
        }


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var item = await _thumbInteractionService.GetList();
            if (item != null)
            {
                return Ok(item);
            }

            return BadRequest($"{nameof(GetList)} returned null.");
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create(ThumbInteractionCreateDto thumbInteractionCreateDto)
        {
            var item = await _thumbInteractionService.Create(thumbInteractionCreateDto);

            return Ok(item);

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ThumbInteractionUpdateDto thumbInteractionUpdateDto )
        {
            var success = await _thumbInteractionService.Update(thumbInteractionUpdateDto);

            if (success)
            {
                return Ok();
            }

            return BadRequest($"{nameof(Update)} returned null.");
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _thumbInteractionService.Delete(id))
            {
                return Ok();
            }

            return BadRequest($"{nameof(Delete)} returned false.");
        }
    }
}
