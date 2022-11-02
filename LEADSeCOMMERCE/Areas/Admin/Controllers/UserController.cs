﻿using DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Utility;

namespace LEADSeCOMMERCE.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Admin)]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return View(_unitOfWork.User.GETALL(u => u.Id != claims.Value));
        }

        public IActionResult Lock(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            _unitOfWork.User.LockUser(Id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UnLock(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            _unitOfWork.User.UnLockUser(Id);
            return RedirectToAction(nameof(Index));
        }
    }

}
