//using BookBulky.Data;
//using BookBulky.Models;
using BookBulky.DataAccess;
using BookBulky.DataAccess.Repository.IRepository;
using BookBulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookBulky.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _unitOfWork.Category.GetAll();
            return View(objCategoryList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(model);
                _unitOfWork.Save();
                TempData["Success"] = "Created is succesfully";
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

            Category category = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(model);
                _unitOfWork.Save();
                TempData["Success"] = "Edited is succesfully";
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
            Category category = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

            if (category != null)
            {

                _unitOfWork.Category.Remove(category);
                _unitOfWork.Save();
                TempData["Success"] = "Deleted is succesfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
