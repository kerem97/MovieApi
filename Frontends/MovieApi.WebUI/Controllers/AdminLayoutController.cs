﻿using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult LayoutUI()
        {
            return View();
        }
    }
}
