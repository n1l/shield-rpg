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
    [Authorize(Roles = "master")]
    public class MasterController : Controller
    {
        private readonly ILogger<MainController> _logger;
        private readonly DataRepository _dataRepository;
        private readonly UserRepository _userRepository;
        private readonly CenterLabRequestsRepository _centerLabRepository;

        public MasterController(
            ILogger<MainController> logger,
            DataRepository dataRepository,
            UserRepository userRepository,
            CenterLabRequestsRepository centerLabRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
            _userRepository = userRepository;
            _centerLabRepository = centerLabRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CenterLab()
        {
            return View(_centerLabRepository.GetRequests());
        }

        public IActionResult EditCenterLabRequest(Guid id)
        {
            return View(_centerLabRepository.GetRequestById(id));
        }

        [HttpPost]
        public IActionResult EditCenterLabRequest(CenterLabRequest centerLabRequest)
        {
            _centerLabRepository.AddRequest(centerLabRequest);
            return RedirectToAction("CenterLab");
        }

        public IActionResult ListUsers()
        {
            return View(_userRepository.GetUsers());
        }

        public IActionResult EditUser(string login)
        {
            return View(_userRepository.GetUserDataByLogin(login));
        }

        [HttpPost]
        public IActionResult EditUser(UserRecord userRecord)
        {
            _userRepository.UpdateUserData(userRecord);
            return RedirectToAction("ListUsers");
        }
    }
}
