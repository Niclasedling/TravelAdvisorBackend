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
    public class CommentController : Controller
    {
        private readonly ILogger<CommentController> _logger;
        public readonly ICommentService _commentService;

        public CommentController(ICommentService commentService, ILogger<CommentController> logger)
        {
            _commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
            _logger = logger;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _commentService.GetById(id);
            if (item != null)
            {
                return Ok(item);
            }

            return BadRequest($"{nameof(GetById)} returned null.");
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var item = await _commentService.GetAll();
            if (item != null)
            {
                return Ok(item);
            }
            return BadRequest($"{nameof(GetAll)} returned null.");
        }


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var item = await _commentService.GetList();
            if (item != null)
            {
                return Ok(item);
            }

            return BadRequest($"{nameof(GetList)} returned null.");
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create(CommentCreateDto commentCreateDto)
        {
            var item = await _commentService.Create(commentCreateDto);

            return Ok(item);

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CommentUpdateDto commentUpdateDto)
        {
            var success = await _commentService.Update(commentUpdateDto);

            if (success)
            {
                return Ok();
            }

            return BadRequest($"{nameof(Update)} returned null.");
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _commentService.Delete(id))
            {
                return Ok();
            }

            return BadRequest($"{nameof(Delete)} returned false.");
        }
    }
}
