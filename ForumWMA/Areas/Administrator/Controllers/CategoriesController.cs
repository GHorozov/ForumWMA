namespace ForumWMA.Areas.Administrator.Controllers
{
    using AutoMapper;
    using ForumWMA.Areas.Administrator.Models.ViewModels.Category;
    using ForumWMA.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CategoriesController : AdministratorController
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
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


    }
}
