﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Origin.Controllers
{
    public class CommonViewsController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult ErrorPin()
        {
            return View();
        }

        public IActionResult ErrorRetiro()
        {
            return View();
        }


    }
}
