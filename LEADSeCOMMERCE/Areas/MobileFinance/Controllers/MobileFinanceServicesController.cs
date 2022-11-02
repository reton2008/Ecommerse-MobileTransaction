using Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using DataAccess.Data.Repository.IRepository;

namespace LEADSeCOMMERCE.Areas.MobileFinance.Controllers
{
    [Authorize]
    [Area("MobileFinance")]
    public class MobileFinanceServicesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MobileFinanceServicesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            MobileFinanceServices mobileFinanceServices = new MobileFinanceServices();
            if (id == null)
            {
                return View(mobileFinanceServices);
            }

            mobileFinanceServices = _unitOfWork.MobileFinanceServices.GET(id.GetValueOrDefault());

            if (mobileFinanceServices == null)
            {
                return NotFound();
            }

            return View(mobileFinanceServices);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(MobileFinanceServices mobileFinanceServices)
        {
            if (ModelState.IsValid)
            {
                if (mobileFinanceServices.Id == 0)
                {
                    _unitOfWork.MobileFinanceServices.Add(mobileFinanceServices);
                }
                else
                {
                    _unitOfWork.MobileFinanceServices.Update(mobileFinanceServices);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(mobileFinanceServices);
        }


        #region API Calls

        [HttpGet]

        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.MobileFinanceServices.GETALL() });
        }


        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.MobileFinanceServices.GET(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error! While Deleting." });
            }

            _unitOfWork.MobileFinanceServices.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successfull." });
        }
        #endregion
    }
}
