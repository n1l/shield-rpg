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
        private readonly UserRepository _userRepository;
        private readonly DataRepository _dataRepository;
        private readonly CenterLabRequestsRepository _centerLabRepository;

        public MasterController(
            ILogger<MainController> logger,
            UserRepository userRepository,
            DataRepository dataRepository,
            CenterLabRequestsRepository centerLabRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _dataRepository = dataRepository;
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
            CenterLabRequest existing = _centerLabRepository.GetRequestById(centerLabRequest.Id);
            if (existing == null) { return RedirectToAction("CenterLab"); }
            existing.Response = centerLabRequest.Response;
            _centerLabRepository.AddRequest(existing);
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
            UserRecord existing = _userRepository.GetUserDataByLogin(userRecord.Login);
            if (existing == null) { return RedirectToAction("CenterLab"); }
            existing.Access = userRecord.Access != 0 ? userRecord.Access : existing.Access;
            existing.HackerRank = userRecord.HackerRank != 0 ? userRecord.HackerRank : existing.HackerRank;
            _userRepository.UpdateUserData(existing);
            return RedirectToAction("ListUsers");
        }

        public IActionResult ListDb()
        {
            return View(_dataRepository.GetRecordList());
        }

        public IActionResult EditRecord(Guid id)
        {
            return View(_dataRepository.GetRecordById(id));
        }

        [HttpPost]
        public IActionResult EditRecord(DataRecord dataRecord)
        {
            _dataRepository.UpdateRecord(dataRecord);
            return RedirectToAction("ListDb");
        }

        public IActionResult CreateRecord()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRecord(DataRecord dataRecord)
        {
            dataRecord.Id = Guid.NewGuid();
            _dataRepository.UpdateRecord(dataRecord);
            return RedirectToAction("ListDb");
        }
    }
}
