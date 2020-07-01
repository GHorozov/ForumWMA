namespace ForumWMA.Areas.Administrator.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Area("Administrator")]
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : Controller
    {
    }
}
