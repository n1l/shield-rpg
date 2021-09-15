using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShieldRPG.Models;
using ShieldRPG.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShieldRPG.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        private readonly ILogger<MainController> _logger;
        private readonly DataRepository _dataRepository;

        public MainController(ILogger<MainController> logger, DataRepository dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MedLab()
        {
            return View();
        }

        public IActionResult ChemLab()
        {
            return View();
        }

        public IActionResult TechLab()
        {
            return View();
        }

        public IActionResult ShieldDb()
        {
            return View();
        }

        public IActionResult InterpolDb()
        {
            return View();
        }

        public IActionResult FbiDb()
        {
            return View();
        }

        /*------------------------------ */

        public IActionResult MedTest(string testId)
        {
            return View(testId);
        }

        [HttpPost]
        public IActionResult DnaRequest(DnaRequest dnaRequest)
        {
            ClaimsPrincipal principal = HttpContext.User;
            var accessClaim = principal.Claims.FirstOrDefault(claim =>
                claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/access");

            (bool success, string message) = _dataRepository.GetDnaResultFor(dnaRequest.BloodCode, int.Parse(accessClaim.Value));
            ViewData["Title"] = success ? "OK" : "Fail";

            return View("ResultView", new TestResponse { ResponseText = message });
        }

        [HttpPost]
        public IActionResult ToxinsRequest(ToxinsRequest toxinsRequest)
        {
            return View();
        }

        [HttpPost]
        public IActionResult InfectRequest(InfectRequest infectRequest)
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubstanceRequest(SubstanceRequest substanceRequest)
        {
            return View();
        }

        [HttpPost]
        public IActionResult MrtRequest(MrtRequest substanceRequest)
        {
            return View();
        }

        /*------------------------------ */

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
