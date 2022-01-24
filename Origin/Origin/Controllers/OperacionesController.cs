using Microsoft.AspNetCore.Mvc;
using Origin.Services;
using Origin.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Origin.Controllers
{
    public class OperacionesController : Controller
    {
        private readonly IBalanceService _balanceService;
        private readonly IRetiroService _retiroService;
        private readonly ITarjetaService _tarjetaService;

        public OperacionesController(IBalanceService bServ, IRetiroService rServ, ITarjetaService tServ)
        {
            _balanceService = bServ;
            _retiroService = rServ;
            _tarjetaService = tServ;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Operacion([FromForm] string number, string operacion)
        {
            var tarjeta = await _tarjetaService.GetByNumber(number);
            if (string.Equals(operacion, "balance", StringComparison.OrdinalIgnoreCase))
            {
                var inserted = await _balanceService.RegisterOperation(number);
                return View("Balance", tarjeta);
            }
            else
            {
                return View("Retiro", number);
            }
        }


        [HttpPost]
        public async Task<IActionResult> BalanceOp([FromForm] string number)
        {
            var tarjeta = await _tarjetaService.GetByNumber(number);
            
                var inserted = await _balanceService.RegisterOperation(number);
                return View("Balance", tarjeta);
           
        }

        [HttpPost]
        public async Task<IActionResult> RetiroOp([FromForm] string numberR)
        {
            return View("Retiro", numberR);
        }




        [HttpPost]
        public async Task<IActionResult> Retiro(string number, string amount)
        {
            var excedeBalance = await _retiroService.ExcedeBalance(number, amount);
            if (excedeBalance)
            {
                TempData["number"] = number;
                return Redirect("/CommonViews/ErrorRetiro");
            }

            var inserted = await _retiroService.RegisterOperation(number, amount);
            return View("RetiroTerminado", inserted);
        }
    }
}
