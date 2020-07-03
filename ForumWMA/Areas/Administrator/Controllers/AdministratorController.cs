namespace ForumWMA.Areas.Administrator.Controllers
{
    using ForumWMA.Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administrator")]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministratorController : Controller
    {
    }
}
