using CompanySystem.BLL;
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

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryCreateVM CategoryVm)
        {
            if (!ModelState.IsValid)
            {
                return View(CategoryVm);
            }
            var status = _categoryManager.CreateCategory(CategoryVm);
            if (status == 0) 
                return View(CategoryVm);
            return RedirectToAction(nameof(Index));
        }

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

        [HttpPost]
        public IActionResult Edit(CategoryEditVM CategoryVm)
        {
            if (!ModelState.IsValid)
            {
                return View(CategoryVm);
            }
            _categoryManager.EditCategory(CategoryVm);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _categoryManager.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
