//using BookBulky.Data;
//using BookBulky.Models;
using BookBulky.DataAccess;
using BookBulky.DataAccess.Repository.IRepository;
using BookBulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookBulky.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();
            return View(objCoverTypeList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CoverType model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(model);
                _unitOfWork.Save();
                TempData["Success"] = "Cover type Created is succesfully";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }

            CoverType coverType = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (coverType == null)
            {
                return NotFound();
            }
            return View(coverType);
        }

        [HttpPost]
        public IActionResult Edit(CoverType model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(model);
                _unitOfWork.Save();
                TempData["Success"] = "Cover Type Edited is succesfully";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        //public IActionResult Delete(int? id)
        //{
        //    if (id == null && id == 0)
        //    {
        //        return NotFound();
        //    }

        //    Category category = _applicationDbContext.Categories.Find(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(category);
        //}

        // [HttpPost]
        public IActionResult Delete(int? id)
        {
            CoverType coverType = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

            if (coverType != null)
            {

                _unitOfWork.CoverType.Remove(coverType);
                _unitOfWork.Save();
                TempData["Success"] = "Cover Type Deleted is succesfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
