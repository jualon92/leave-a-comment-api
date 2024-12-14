using leave_a_comment_api.Model;
using Microsoft.AspNetCore.Mvc;
using leave_a_comment_api.Services;

namespace leave_a_comment_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {


        private readonly CommentService _commentService;

        private readonly ILogger<CommentController> _logger;

        public CommentController(ILogger<CommentController> logger, CommentService commentService)
        {
            _logger = logger;
            _commentService = commentService;
        }

        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return _commentService.GetAllCommentsAsync().Result;
        }

        //Copilot: make a http req that receives an string representing the comment

        [HttpPost]
        public async Task<IActionResult> PostComment([FromBody] string text)
        {
            if (text == null)
            {
                return BadRequest();
            }
            if (string.IsNullOrWhiteSpace(text))
            {
                return BadRequest("Comment text cannot be empty.");
            }

            await _commentService.AddCommentAsync(text);
            return Ok();
        }
    }
}