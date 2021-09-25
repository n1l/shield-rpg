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
        private readonly CenterLabRequestsRepository _centerLabRepository;

        public MainController(ILogger<MainController> logger, DataRepository dataRepository, CenterLabRequestsRepository centerLabRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
            _centerLabRepository = centerLabRepository;
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

        public IActionResult CenterLab()
        {
            ClaimsPrincipal principal = HttpContext.User;
            return View(_centerLabRepository.GetRequests(principal.Identity.Name));
        }

        public IActionResult ShieldDb()
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

        public IActionResult CenterLabTest()
        {
            return View("CenterLabTest");
        }

        [HttpPost]
        public IActionResult CenterLabRequest(CenterLabRequest centerLabRequest)
        {
            ClaimsPrincipal principal = HttpContext.User;
            _centerLabRepository.AddRequest(principal.Identity.Name, centerLabRequest);
            return RedirectToAction("CenterLab");
        }

        /*------------------------------ */

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
