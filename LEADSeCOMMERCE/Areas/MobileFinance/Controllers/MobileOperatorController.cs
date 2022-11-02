using Models;
using System;
using System.Linq;
using Models.MobileFinance;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using DataAccess.Data.Repository.IRepository;

namespace LEADSeCOMMERCE.Areas.MobileFinance.Controllers
{

    [Authorize]
    [Area("MobileFinance")]

    public class MobileOperatorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MobileOperatorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            MobileOperator mobileOperator = new MobileOperator();
            if (id == null)
            {
                return View(mobileOperator);
            }

            mobileOperator = _unitOfWork.MobileOperator.GET(id.GetValueOrDefault());

            if (mobileOperator == null)
            {
                return NotFound();
            }

            return View(mobileOperator);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(MobileOperator mobileOperator)
        {
            if (ModelState.IsValid)
            {
                if (mobileOperator.Id == 0)
                {
                    _unitOfWork.MobileOperator.Add(mobileOperator);
                }
                else
                {
                    _unitOfWork.MobileOperator.Update(mobileOperator);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(mobileOperator);
        }


        #region API Calls

        [HttpGet]

        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.MobileOperator.GETALL() });
        }


        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.MobileOperator.GET(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error! While Deleting." });
            }

            _unitOfWork.MobileOperator.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successfull." });
        }
        #endregion
    }
}

