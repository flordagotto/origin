using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Origin.Dto;
using Origin.Models;
using Origin.Services.Repo;

namespace Origin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITarjetaService _tarjetaService;

        public HomeController(ITarjetaService tServ)
        {
            _tarjetaService = tServ;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Enter(string number)
        {
            var entity = await _tarjetaService.GetByNumber(number);
            if (entity == null)
            {
                return Redirect("/CommonViews/Error");
            }
            entity.Tries = 0;
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Pin(string number, string pin)
        {
            var _number = Convert.ToInt64(number);
            var isCorrect = await _tarjetaService.IsCorrectPin(_number, Convert.ToInt32(pin));
            if(isCorrect == -1)
            {
                TempData["number"] = number;
                return Redirect("/Operaciones/Index");
            }
            else if(isCorrect == 4)
            {
                await _tarjetaService.BlockCard(_number);
                TempData["number"] = number;
                return Redirect("/CommonViews/ErrorPin");
            }
            else
            {
                var entity = new TarjetaDto
                {
                    Numero = _number,
                    Tries = isCorrect
                };
                return View("Enter", entity);
            }
        }
    }
}
