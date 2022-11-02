using Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Models.MobileFinance;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Models.MobileFinance.viewModels;
using Microsoft.AspNetCore.Authorization;
using DataAccess.Data.Repository.IRepository;

namespace LEADSeCOMMERCE.Areas.MobileFinance.Controllers
{
    [Authorize]
    [Area("MobileFinance")]

    public class CashWalletController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CashWalletController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            CashWallet cashWallet = new CashWallet();
            if (id == null)
            {
                return View(cashWallet);
            }

            cashWallet = _unitOfWork.CashWallet.GET(id.GetValueOrDefault());

            if (cashWallet == null)
            {
                return NotFound();
            }

            return View(cashWallet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CashWallet cashWallet)
        {
            if (ModelState.IsValid)
            {
                if (cashWallet.Id == 0)
                {
                    _unitOfWork.CashWallet.Add(cashWallet);
                }
                else
                {
                    _unitOfWork.CashWallet.Update(cashWallet);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(cashWallet);
        }


        #region API Calls

        [HttpGet]

        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.CashWallet.GETALL() });
        }


        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.CashWallet.GET(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error! While Deleting." });
            }

            _unitOfWork.CashWallet.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successfull." });
        }
        #endregion

    }
}
