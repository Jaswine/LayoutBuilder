using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutBuilder.Dtos.Project;

namespace LayoutBuilder.Services.CommentServices
{
    public interface ICommentService
    {
        Task<CommentResponse<Comment>> CreateNewComment(int id, string userId, CreateCommentDto newComment);
        Task<CommentResponse<Comment>> RemoveComment(int id, int commentId, string userId);
    }
}