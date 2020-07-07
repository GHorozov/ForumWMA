namespace ForumWMA.Areas.Administrator.Controllers
{
    using AutoMapper;
    using ForumWMA.Areas.Administrator.Models.InputModels.Category;
    using ForumWMA.Areas.Administrator.Models.ViewModels.Category;
    using ForumWMA.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var categoryModel = await this.categoryService.GetCategoryById<EditCategoryInputModel>(id);
            //var category  = await this.categoryService.GetCategoryById(id);
            if (categoryModel == null)
            {
                return this.RedirectToAction(nameof(All));
            }

            return this.View(categoryModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditCategoryInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.categoryService.Edit(id, inputModel.Name, inputModel.Title, inputModel.Description, inputModel.ImageUrl);

            return RedirectToAction(nameof(All));
        }
    }
}
