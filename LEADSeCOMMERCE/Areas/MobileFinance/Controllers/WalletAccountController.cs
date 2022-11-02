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
    public class WalletAccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public WalletVM WalletVM { get; set; }

        public WalletAccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Upsert(int? id)
        {
            WalletVM = new WalletVM()
            {
                WalletAccount = new WalletAccount(),
                MobileFinanceServicesList = _unitOfWork.MobileFinanceServices.GetServicesListForDropDown(),
                MobileOperatorList = _unitOfWork.MobileOperator.GetOperatorsListForDropDown(),
            };
            if (id != null)
            {
                WalletVM.WalletAccount = _unitOfWork.WalletAccount.GET(id.GetValueOrDefault());
            }
            return View(WalletVM);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(WalletVM walletVM)
        {
            if (ModelState.IsValid)
            {
                if (walletVM.WalletAccount.Id == 0)
                {
                    _unitOfWork.WalletAccount.Add(walletVM.WalletAccount);
                }
                else
                {               
                    _unitOfWork.WalletAccount.Update(walletVM.WalletAccount);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(walletVM);
            }
        }


        #region API Calls

        [HttpGet]

        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.WalletAccount.GETALL(includeProperties: "MobileFinanceServices,MobileOperator") });
        }


        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.WalletAccount.GET(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error! While Deleting." });
            }

            _unitOfWork.WalletAccount.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successfull." });
        }
        #endregion
    }
}

