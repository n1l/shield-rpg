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

        public MainController(
            ILogger<MainController> logger,
            DataRepository dataRepository,
            CenterLabRequestsRepository centerLabRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
            _centerLabRepository = centerLabRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "medlab")]
        public IActionResult MedLab()
        {
            return View();
        }

        [Authorize(Roles = "chemlab")]
        public IActionResult ChemLab()
        {
            return View();
        }

        [Authorize(Roles = "techlab")]
        public IActionResult TechLab()
        {
            return View();
        }

        public IActionResult CenterLab()
        {
            ClaimsPrincipal principal = HttpContext.User;
            return View(_centerLabRepository.GetRequests(principal.Identity.Name));
        }

        [Authorize(Roles = "shielddb")]
        public IActionResult ShieldDb()
        {
            return View();
        }

        public IActionResult CenterLabTest()
        {
            return View();
        }

        /*------------------------------ */

        public IActionResult ProcessRequest(string requestType)
        {
            return View(requestType);
        }

        /*------------------------------ MedLab*/

        [Authorize(Roles = "medlab")]
        [HttpPost]
        public IActionResult DnaRequest(DnaRequest dnaRequest)
        {
            ClaimsPrincipal principal = HttpContext.User;
            var accessClaim = principal.Claims.FirstOrDefault(claim =>
                claim.Type == ShieldRpgClaimTypes.Access);

            (bool success, string message) = _dataRepository.GetDnaResultFor(dnaRequest?.BloodCode, int.Parse(accessClaim.Value));
            ViewData["Title"] = success ? "OK" : "Fail";

            return View("ResultView", new TestResponse { ResponseText = message });
        }

        [Authorize(Roles = "medlab")]
        [HttpPost]
        public IActionResult ToxinsRequest(ToxinsRequest toxinsRequest)
        {
            ClaimsPrincipal principal = HttpContext.User;
            var accessClaim = principal.Claims.FirstOrDefault(claim =>
                claim.Type == ShieldRpgClaimTypes.Access);

            (bool success, string message) = _dataRepository.GetToxinResultFor(toxinsRequest?.ToxinsCode, int.Parse(accessClaim.Value));
            ViewData["Title"] = success ? "OK" : "Fail";

            return View("ResultView", new TestResponse { ResponseText = message });
        }

        [Authorize(Roles = "medlab")]
        [HttpPost]
        public IActionResult InfectRequest(InfectRequest infectRequest)
        {
            ClaimsPrincipal principal = HttpContext.User;
            var accessClaim = principal.Claims.FirstOrDefault(claim =>
                claim.Type == ShieldRpgClaimTypes.Access);

            (bool success, string message) = _dataRepository.GetInfectResultFor(infectRequest?.InfectCode, int.Parse(accessClaim.Value));
            ViewData["Title"] = success ? "OK" : "Fail";

            return View("ResultView", new TestResponse { ResponseText = message });
        }

        [Authorize(Roles = "medlab")]
        [HttpPost]
        public IActionResult MrtRequest(MrtRequest mrtRequest)
        {
            ClaimsPrincipal principal = HttpContext.User;
            var accessClaim = principal.Claims.FirstOrDefault(claim =>
                claim.Type == ShieldRpgClaimTypes.Access);

            (bool success, string message) = _dataRepository.GetMrtResultFor(mrtRequest?.MrtCode, int.Parse(accessClaim.Value));
            ViewData["Title"] = success ? "OK" : "Fail";

            return View("ResultView", new TestResponse { ResponseText = message });
        }

        /*------------------------------ ChemLab*/

        [Authorize(Roles = "chemlab")]
        [HttpPost]
        public IActionResult SubstanceRequest(SubstanceRequest substanceRequest)
        {
            ClaimsPrincipal principal = HttpContext.User;
            var accessClaim = principal.Claims.FirstOrDefault(claim =>
                claim.Type == ShieldRpgClaimTypes.Access);

            (bool success, string message) = _dataRepository.GetSubstancResultFor(substanceRequest?.SubstanceCode, int.Parse(accessClaim.Value));
            ViewData["Title"] = success ? "OK" : "Fail";

            return View("ResultView", new TestResponse { ResponseText = message });
        }

        /*------------------------------ TechLab */

        [Authorize(Roles = "techlab")]
        [HttpPost]
        public IActionResult ScanRequest(ScanRequest scanRequest)
        {
            ClaimsPrincipal principal = HttpContext.User;
            var accessClaim = principal.Claims.FirstOrDefault(claim =>
                claim.Type == ShieldRpgClaimTypes.Access);

            (bool success, string message) = _dataRepository.GetScanResultFor(scanRequest?.ScanCode, int.Parse(accessClaim.Value));
            ViewData["Title"] = success ? "OK" : "Fail";

            return View("ResultView", new TestResponse { ResponseText = message });
        }

        [Authorize(Roles = "techlab")]
        [HttpPost]
        public IActionResult SpectrogramRequest(SpectrogramRequest spectrogramRequest)
        {
            ClaimsPrincipal principal = HttpContext.User;
            var accessClaim = principal.Claims.FirstOrDefault(claim =>
                claim.Type == ShieldRpgClaimTypes.Access);

            (bool success, string message) = _dataRepository.GetScanResultFor(spectrogramRequest?.SpectrogramCode, int.Parse(accessClaim.Value));
            ViewData["Title"] = success ? "OK" : "Fail";

            return View("ResultView", new TestResponse { ResponseText = message });
        }

        /*------------------------------ ShieldDb */

        [Authorize(Roles = "shielddb")]
        [HttpPost]
        public IActionResult PersonalDataRequest(PersonalDataRequest personalDataRequest)
        {
            ClaimsPrincipal principal = HttpContext.User;
            var accessClaim = principal.Claims.FirstOrDefault(claim =>
                claim.Type == ShieldRpgClaimTypes.Access);

            (bool success, string message) = _dataRepository.GetScanResultFor(personalDataRequest?.PersonalDataCode, int.Parse(accessClaim.Value));
            ViewData["Title"] = success ? "OK" : "Fail";

            return View("ResultView", new TestResponse { ResponseText = message });
        }

        [Authorize(Roles = "shielddb")]
        [HttpPost]
        public IActionResult OperationsRequest(OperationsRequest operationsRequest)
        {
            ClaimsPrincipal principal = HttpContext.User;
            var accessClaim = principal.Claims.FirstOrDefault(claim =>
                claim.Type == ShieldRpgClaimTypes.Access);

            (bool success, string message) = _dataRepository.GetScanResultFor(operationsRequest?.OperationsCode, int.Parse(accessClaim.Value));
            ViewData["Title"] = success ? "OK" : "Fail";

            return View("ResultView", new TestResponse { ResponseText = message });
        }

        [Authorize(Roles = "shielddb")]
        [HttpPost]
        public IActionResult ScienceRequest(ScienceRequest scienceRequest)
        {
            ClaimsPrincipal principal = HttpContext.User;
            var accessClaim = principal.Claims.FirstOrDefault(claim =>
                claim.Type == ShieldRpgClaimTypes.Access);

            (bool success, string message) = _dataRepository.GetScanResultFor(scienceRequest?.ScientCode, int.Parse(accessClaim.Value));
            ViewData["Title"] = success ? "OK" : "Fail";

            return View("ResultView", new TestResponse { ResponseText = message });
        }

        /*------------------------------ CenterLab */

        [HttpPost]
        public IActionResult CenterLabRequest(CenterLabRequest centerLabRequest)
        {
            if (centerLabRequest == null) { return RedirectToAction("CenterLab"); }

            ClaimsPrincipal principal = HttpContext.User;
            centerLabRequest.UserName = principal.Identity.Name;
            centerLabRequest.Id = Guid.NewGuid();
            _centerLabRepository.AddRequest(centerLabRequest);
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
