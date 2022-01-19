using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            CompanyViewModel companyVm = new()
            {
                Company = new()
            };
            if (id == null || id == 0)
            {
                //Instead of doing this we used ProductVM
                //view bag to send data to the view that dont belong to model
                //ViewBag.CategoryList = CategoryList;
                //view data (alternative)
                //ViewData["CoverTypeList"] = CoverTypeList;
                return View(companyVm);
            }
            else
            {
                companyVm.Company = _unitOfWork.CompanyRepository.GetFirstOrDefault(i => i.Id == id);
                return View(companyVm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CompanyViewModel obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Company.Id == 0)
                {
                    _unitOfWork.CompanyRepository.Add(obj.Company);
                    TempData["success"] = "Company created successfully!";
                }
                else
                {
                    _unitOfWork.CompanyRepository.Update(obj.Company);
                    TempData["success"] = "Company updated successfully!";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var companyList = _unitOfWork.CompanyRepository.GetAll();
            return Json(new { data = companyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.CompanyRepository.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.CompanyRepository.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Company deleted successfully" });

        }
        #endregion
    }
}

