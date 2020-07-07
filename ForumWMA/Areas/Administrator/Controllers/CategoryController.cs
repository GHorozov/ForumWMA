namespace ForumWMA.Areas.Administrator.Controllers
{
    using AutoMapper;
    using ForumWMA.Areas.Administrator.Models.InputModels.Category;
    using ForumWMA.Areas.Administrator.Models.ViewModels.Category;
    using ForumWMA.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CategoryController : AdministratorController
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult All(int? count)
        {
            var resultModel = this.categoryService.All<CategoryViewModel>(count);

            return View(resultModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var categoryId = await this.categoryService.Create(inputModel.Name, inputModel.Title, inputModel.Description, inputModel.ImageUrl);
            if (string.IsNullOrEmpty(categoryId))
            {
                return this.Redirect("/");
            }

            return RedirectToAction(nameof(All));
        }
    }
}
