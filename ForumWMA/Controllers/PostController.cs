using ForumWMA.Data.Models;
using ForumWMA.Models.InputModels.Post;
using ForumWMA.Models.ViewModels.Category;
using ForumWMA.Models.ViewModels.Post;
using ForumWMA.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWMA.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;
        private readonly UserManager<ForumWMAUser> userManager;

        public PostController(IPostService postService, ICategoryService categoryService, UserManager<ForumWMAUser> userManager)
        {
            this.postService = postService;
            this.categoryService = categoryService;
            this.userManager = userManager;
        }

        public IActionResult GetPostById(string id)
        {
            var viewModel = this.postService.ById<PostViewModel>(id);
            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            var categories = this.categoryService.All<CategoryDropDownViewModel>(null);
            var viewModel = new PostCreateInputModel()
            {
                Categories = categories,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostCreateInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var postId = await this.postService.Create(inputModel.Title, inputModel.Content, inputModel.CategoryId, user.Id);

            return this.RedirectToAction(nameof(this.GetPostById), new { id = postId });
        }
    }
}
