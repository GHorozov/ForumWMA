namespace ForumWMA.Areas.Administrator.Controllers
{
    using ForumWMA.Areas.Administrator.Models.InputModels.User;
    using ForumWMA.Areas.Administrator.Models.ViewModels.User;
    using ForumWMA.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserController : AdministratorController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var users = this.userService.GetAllUsers<UserViewModel>().ToList();

            return View(users);
        }

        [HttpGet]
        public IActionResult Roles(string id)
        {
            var userRoles = this.userService.GetUserRoles(id)
                .GetAwaiter()
                .GetResult()
                .ToList();

            var userRolesModel = new RolesViewModel()
            {
                Id = id,
                Roles = userRoles
            };

            return this.View(userRolesModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var userModel = await this.userService.GetUserById<DeleteUserViewModel>(id);
            if (userModel == null)
            {
                return this.RedirectToAction(nameof(All));
            }

            return View(userModel);
        }

        [HttpGet]
        public async Task<IActionResult> Destroy(string id)
        {
            await this.userService.DeleteById(id);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword(string id)
        {
            var userModel = await this.userService.GetUserById<AdminChangePasswordInputModel>(id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(string id, AdminChangePasswordInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var result = await this.userService.ChangePassword(id, inputModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(All));
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(inputModel);
            }
        }
    }
}
