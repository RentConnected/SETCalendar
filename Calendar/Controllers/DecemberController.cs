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
    public class DecemberController : Controller
    {
        private readonly IStringLocalizer<DecemberController> _localizer;

        public DecemberController(IStringLocalizer<DecemberController> localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index(int date)
        {
            ViewData["Url"] = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}{this.Request.Path}{this.Request.QueryString}";

            if (date > 0)
            {
                ViewData["BaseUrl"] = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/{this.Request.Path.ToString().Split('/')[1]}/{this.ControllerContext.RouteData.Values["controller"].ToString()}";
                ViewData["Title"] = _localizer[$"{date}title"];
                ViewData["Description"] = _localizer[$"{date}description"];
                ViewData["Image"] = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/{this.Request.Path.ToString().Split('/')[1]}/{this.ControllerContext.RouteData.Values["controller"].ToString()}/images/image {date}.mobile.jpg";

                return View($"{date}");
            }
            else
            {
                ViewData["BaseUrl"] = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}{this.Request.Path}";
                ViewData["Title"] = _localizer[$"title"];
                ViewData["Image"] = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/{this.Request.Path.ToString().Split('/')[1]}/{this.ControllerContext.RouteData.Values["controller"].ToString()}/images/index.jpg";
            }

            return View();
        }
    }
}