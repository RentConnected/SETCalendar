using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Calendar.Models;
using Microsoft.Extensions.Localization;

namespace Calendar.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            ViewData["Url"] = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}{this.Request.Path}";
            ViewData["Title"] = _localizer["title"];
            ViewData["Image"] = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/{this.Request.Path.ToString().Split('/')[1]}/images/index.jpg";

            return View();
        }
    }
}
