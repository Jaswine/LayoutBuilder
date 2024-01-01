using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutBuilder.Dtos.Project;
using Microsoft.EntityFrameworkCore;

namespace LayoutBuilder.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CommentService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // ! _____________  SHOW ALL COMMENTS _____________
        public async Task<CommentResponse<List<Comment>>> GetAllComments(int id)
        {
            var commentResponse = new CommentResponse<List<Comment>>();

            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);

            if (project is not null) {
                commentResponse.Data = await _context.Comments.Where(p => p.ProjectId == id).ToListAsync();
            } else {
                commentResponse.Success = false;
                commentResponse.Message = "Project not found";
            }
            return commentResponse;
        }

        // ! _____________  CREATE A NEW COMMENT _____________
        public async Task<CommentResponse<Comment>> CreateNewComment(int id, string userId, CreateCommentDto newComment)
        {
            var commentResponse = new CommentResponse<Comment>();
            DateTime currentDateAndTime = DateTime.Now;

            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);

            if (project is not null)
            {
                if (project.IsPublic == true) {
                    var comment = new Comment();
                    comment.ProjectId = project.Id;
                    comment.Project = project;
                    comment.UserId = int.Parse(userId);
                    comment.User = await _context.Users.FirstOrDefaultAsync(p => p.Id == int.Parse(userId));
                    comment.Text = newComment.Text;
                
                    comment.UpdatedAt = currentDateAndTime;
                    comment.CreatedAt = currentDateAndTime;

                    _context.Comments.Add(comment);
                    await _context.SaveChangesAsync();

                    commentResponse.Data = comment;
                    commentResponse.Message = "Comment created successfully";
                } else {
                    commentResponse.Success = false;
                    commentResponse.Message = "Project not found";
                }
            } else {
                commentResponse.Success = false;
                commentResponse.Message = "Project not found";
            }

            return commentResponse;
        }

        // ! _____________  REMOVE COMMENT _____________
        public async Task<CommentResponse<Comment>> RemoveComment(int id, int commentId, string userId)
        {
            var commentResponse = new CommentResponse<Comment>();

            var comment = await _context.Comments.FirstOrDefaultAsync(p => p.Id == commentId);

            if (comment is not null)
            {
                if (comment.UserId == int.Parse(userId)) {
                    _context.Comments.Remove(comment);
                    await _context.SaveChangesAsync();

                    commentResponse.Message = "Project removed successfully!";
                    return commentResponse;
                }
            } 
            commentResponse.Success = false;
            commentResponse.Message = "Project Not Found";
            return commentResponse;
        }

    }
}