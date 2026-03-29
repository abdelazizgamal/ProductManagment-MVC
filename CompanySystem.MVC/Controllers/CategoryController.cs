using CompanySystem.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanySystem.MVC
{
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var CategoriesVm = _categoryManager.GetCategories();
            return View(CategoriesVm);
        }

        [Authorize(Roles = $"{SystemRoles.User},{SystemRoles.Admin}")]
        [HttpGet]
        public IActionResult Details(int id)
        {
            var CategoryVM = _categoryManager.GetCategoryById(id);
            if (CategoryVM == null)
            {
                return RedirectToAction(nameof(Index));
            }
                
            return View(CategoryVM);
        }

        [Authorize(Roles = SystemRoles.Admin)]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = SystemRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryCreateVM CategoryVm)
        {
            if (!ModelState.IsValid)
            {
                return View(CategoryVm);
            }
            
            var status = _categoryManager.CreateCategory(CategoryVm);
            if (status == 0) 
            {
                ModelState.AddModelError("", "Failed to create category. Please try again.");
                return View(CategoryVm);
            }
            
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = SystemRoles.Admin)]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var CategoryVm = _categoryManager.GetCategoryByIdEdit(id);
            if (CategoryVm == null)
            {
                return RedirectToAction(nameof(Index));
            }
            
            return View(CategoryVm);
        }

        [Authorize(Roles = SystemRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryEditVM CategoryVm)
        {
            if (!ModelState.IsValid)
            {
                return View(CategoryVm);
            }
            
            _categoryManager.EditCategory(CategoryVm);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = SystemRoles.Admin)]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _categoryManager.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
