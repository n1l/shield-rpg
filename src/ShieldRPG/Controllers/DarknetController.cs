using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
    public class DarknetController : Controller
    {
        private readonly ILogger<MainController> _logger;
        private readonly DataRepository _dataRepository;
        private readonly WordsRepository _wordsRepository;
        private readonly UserRepository _userRepository;
        private readonly HackerRepository _hackerRepository;

        public DarknetController(
            ILogger<MainController> logger,
            DataRepository dataRepository,
            WordsRepository wordsRepository,
            UserRepository userRepository,
            HackerRepository hackerRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
            _wordsRepository = wordsRepository;
            _userRepository = userRepository;
            _hackerRepository = hackerRepository;
        }

        [Authorize(Roles = "darknet")]
        public IActionResult Index()
        {
            return View(_dataRepository.GetRecordList("PersonalDataRequest", "OperationsRequest", "ScienceRequest"));
        }

        [Authorize(Roles = "darknet")]
        public IActionResult Terminal(Guid id)
        {
            return View(_dataRepository.GetRecordById(id));
        }

        [HttpGet]
        public IActionResult AttemptFinished(bool success)
        {
            ClaimsPrincipal principal = HttpContext.User;
            string login = principal.Claims.FirstOrDefault(claim =>
                claim.Type == ShieldRpgClaimTypes.Login)?.Value;
            _hackerRepository.UpdateAttempt(login, success);

            return Ok();
        }

        public IActionResult GetAssesmentData(int count, int length)
        {
            ClaimsPrincipal principal = HttpContext.User;

            string login = principal.Claims.FirstOrDefault(claim =>
                claim.Type == ShieldRpgClaimTypes.Login)?.Value;

            if (!_hackerRepository.CanHack(login))
            {
                return Json(string.Empty);
            }
            
            var userData = _userRepository.GetUserDataByLogin(login);
            var assesment = new AssesmentResult
            {
                Attempts = _hackerRepository.GetAttempts(userData.HackerRank),
                Words = _wordsRepository.GetWords(count, length)
            };

            return Json(JsonConvert.SerializeObject(assesment));
        }

        public IActionResult GetDataRecord(Guid id)
        {
            var record = _dataRepository.GetRecordById(id);

            return Json(JsonConvert.SerializeObject(record));
        }
    }
}
