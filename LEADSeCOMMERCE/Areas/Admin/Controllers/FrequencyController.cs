using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace LEADSeCOMMERCE.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class FrequencyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FrequencyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Frequency frequency = new Frequency();
            if (id == null)
            {
                return View(frequency);
            }

            frequency = _unitOfWork.Frequency.GET(id.GetValueOrDefault());

            if (frequency == null)
            {
                return NotFound();
            }

            return View(frequency);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Frequency frequency)
        {
            if (ModelState.IsValid)
            {
                if (frequency.Id == 0)
                {
                    _unitOfWork.Frequency.Add(frequency);
                }
                else
                {
                    _unitOfWork.Frequency.Update(frequency);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(frequency);
        }

        #region API Calls

        [HttpGet]

        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Frequency.GETALL() });
        }


        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Frequency.GET(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error! While Deleting." });
            }

            _unitOfWork.Frequency.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successfull." });
        }
        #endregion
    }
}