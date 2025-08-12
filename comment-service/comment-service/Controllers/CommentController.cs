using Microsoft.AspNetCore.Mvc;
using comment_service.Services;
using comment_service.Model;
using Microsoft.AspNetCore.Authorization;

namespace comment_service.Controllers
{
    [ApiController]
    [Route("")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService comment_service;

        public CommentController(ICommentService comment_service)
        {
            this.comment_service = comment_service;
        }

        [HttpGet("SayHello")]
        public string SayHello()
        {
            return this.comment_service.SayHello();
        }

        [HttpPost("addComment")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddComment([FromBody] CommentDTO commentDto)
        {
            if (commentDto == null)
            {
                return BadRequest("Invalid comment data.");
            }

            try
            {
                var new_comment = await comment_service.AddComment(commentDto);
                return CreatedAtAction(nameof(AddComment), new { id = new_comment.id }, new_comment);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getAllComments")]
        public async Task<IActionResult> getAllComments()
        {
            try
            {
                var comments = await comment_service.GetAllComments();

                if (comments == null || comments.Count == 0)
                {
                    return NotFound("No comments found.");
                }

                return Ok(comments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getCommentsByRestaurantId/{id}")]
        public async Task<IActionResult> getCommentsByRestaurantId(string id)
        {
            try
            {
                var comments = await comment_service.GetCommentsByRestaurantId(id);

                if (comments == null || comments.Count == 0)
                {
                    return NotFound("No comments found.");
                }

                return Ok(comments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("updateComment/{id}")]
        [Authorize(Roles = "User,Restaurant,Administrator")]
        public async Task<IActionResult> UpdateComment(string id, [FromBody] CommentDTO updatedDto)
        {
            if (updatedDto == null)
            {
                return BadRequest("Invalid comment data.");
            }

            try
            {
                var updatedComment = await comment_service.UpdateComment(id, updatedDto);
                if (updatedComment == null)
                {
                    return NotFound($"No comment found with ID = {id}");
                }

                return Ok(updatedComment);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("deleteComment/{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            try
            {
                var deleted = await comment_service.DeleteComment(id);
                if (!deleted)
                {
                    return NotFound($"No comment found with ID = {id}");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost("addNews")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddNews([FromBody] NewsDTO newsDto)
        {
            if (newsDto == null || string.IsNullOrWhiteSpace(newsDto.content))
            {
                return BadRequest("Invalid news data.");
            }

            try
            {
                var newNews = await comment_service.AddNews(newsDto);
                return CreatedAtAction(nameof(AddNews), new { id = newNews.id }, newNews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("deleteNews/{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteNews(string id)
        {
            try
            {
                var result = await comment_service.DeleteNews(id);
                if (!result)
                {
                    return NotFound($"No news found with ID = {id}");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getAllNews")]
        public async Task<IActionResult> getAllNews()
        {
            try
            {
                var news = await comment_service.GetAllNews();

                if (news == null || news.Count == 0)
                {
                    return NotFound("No news found.");
                }

                return Ok(news);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
