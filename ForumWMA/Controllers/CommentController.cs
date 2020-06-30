namespace ForumWMA.Controllers
{
    using ForumWMA.Data.Models;
    using ForumWMA.Models.InputModels.Comment;
    using ForumWMA.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Authorize]
    public class CommentController : Controller
    {
        private readonly UserManager<ForumWMAUser> userManager;
        private readonly ICommentService commentService;

        public CommentController(UserManager<ForumWMAUser> userManager, ICommentService commentService)
        {
            this.userManager = userManager;
            this.commentService = commentService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateCommentInputModel inputModel)
        {
            if (inputModel.ParentId != null)
            {
                if (!this.commentService.IsInPostId(inputModel.ParentId, inputModel.PostId))
                {
                    return this.BadRequest();
                }
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.commentService.Create(user.Id, inputModel.PostId, inputModel.Content, inputModel.ParentId);

            return this.RedirectToAction("GetPostById", "Post", new { id = inputModel.PostId });
        }
    }
}
