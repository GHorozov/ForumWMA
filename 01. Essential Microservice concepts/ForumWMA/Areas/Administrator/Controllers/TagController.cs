namespace ForumWMA.Areas.Administrator.Controllers
{
    using ForumWMA.Areas.Administrator.Models.InputModels.Tag;
    using ForumWMA.Areas.Administrator.Models.ViewModels.Tag;
    using ForumWMA.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing.Template;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TagController : AdministratorController
    {
        private readonly ITagService tagService;

        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        public IActionResult All()
        {
            var tags = this.tagService.All<TagViewModel>();

            return this.View(tags);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTagInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var tagId = await this.tagService.Create(inputModel.Name);
            if (string.IsNullOrEmpty(tagId))
            {
                return this.Redirect("/");
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var tagModel = await this.tagService.GetTagById<EditTagInputModel>(id);
            if (tagModel == null)
            {
                return this.RedirectToAction(nameof(All));
            }

            return this.View(tagModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditTagInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.tagService.Edit(id, inputModel.Name); 

            return RedirectToAction(nameof(All));
        }
    }
}
