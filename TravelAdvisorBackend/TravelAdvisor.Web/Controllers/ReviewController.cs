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
    public class ReviewController : Controller
    {
        private readonly ILogger<AttractionController> _logger;
        public readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService, ILogger<AttractionController> logger)
        {
            _reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
            _logger = logger;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _reviewService.GetById(id);
            if (item != null)
            {
                return Ok(item);
            }

            return BadRequest($"{nameof(GetById)} returned null."); // Tillfällig - fixa sen
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var item = await _reviewService.GetAll();
            if (item != null)
            {
                return Ok(item);
            }
            return BadRequest($"{nameof(GetAll)} returned null."); // Tillfällig - fixa sen
        }


        [HttpGet("GetListById")]
        public async Task<IActionResult> GetListById(Guid id)
        {
            var item = await _reviewService.GetListById(id);
            if (item != null)
            {
                return Ok(item);
            }

            return BadRequest($"{nameof(GetListById)} returned null."); // Tillfällig - fixa sen
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _reviewService.Delete(id))
            {
                return Ok();
            }

            return BadRequest($"{nameof(Delete)} returned false."); // Tillfällig - fixa sen
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ReviewCreateDto newReview)
        {
            var item = await _reviewService.Create(newReview);

            return Ok(item);

            /*return BadRequest($"{nameof(Create)} returned null.");*/ // Tillfällig - fixa sen
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ReviewUpdateDto updateReview)
        {
            var success = await _reviewService.Update(updateReview);

            if (success)
            {
                return Ok();
            }

            return BadRequest($"{nameof(Update)} returned null."); // Tillfällig - fixa sen
        }
    }
}
