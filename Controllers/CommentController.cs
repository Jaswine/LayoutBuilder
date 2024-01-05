using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutBuilder.Dtos.Project;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using LayoutBuilder.Utils;
using LayoutBuilder.Services.CommentServices;

namespace LayoutBuilder.Controllers
{
    [ApiController]
    [Route("api/project")]
    public class CommentController : ControllerBase
    {
         private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService) 
        {
            _commentService = commentService;
        }

        [HttpPost("{id}/comments")]
        public async Task<ActionResult<Comment>> AddComment(int id, CreateCommentDto newComment) 
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = new JWTGenerator().DecodeJwtToken(token);

            return Ok( await _commentService.CreateNewComment(id, userId, newComment));
        }

        [HttpDelete("{id}/comments/{commentId}")]
        public async Task<ActionResult<Comment>> RemoveComment(int id, int commentId) 
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = new JWTGenerator().DecodeJwtToken(token);

            return Ok( await _commentService.RemoveComment(id, commentId, userId));
        }

    }
}