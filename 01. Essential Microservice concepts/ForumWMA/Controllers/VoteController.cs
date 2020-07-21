namespace ForumWMA.Controllers
{
    using ForumWMA.Data.Models;
    using ForumWMA.Models.InputModels.Vote;
    using ForumWMA.Models.ViewModels.Vote;
    using ForumWMA.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService voteService;
        private readonly UserManager<ForumWMAUser> userManager;
        private readonly IPostService postService;

        public VoteController(IVoteService voteService, UserManager<ForumWMAUser> userManager, IPostService postService)
        {
            this.voteService = voteService;
            this.userManager = userManager;
            this.postService = postService;
        }

        [HttpPost]
        public async Task<ActionResult<VoteViewModel>> VoteAsync(VoteInputModel inputModel)
        {
            var isPostIdExist = this.postService.IsExist(inputModel.PostId);
            if (isPostIdExist == false)
            {
                return this.NotFound(inputModel.PostId);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.voteService.VoteAsync(inputModel.PostId, user.Id.ToString(), inputModel.IsUpVote);
            var votes = this.voteService.GetVotesCount(inputModel.PostId);

            return new VoteViewModel() { VotesCount = votes };
        }
    }
}
