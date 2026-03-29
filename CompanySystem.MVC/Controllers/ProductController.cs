using Microsoft.AspNetCore.Mvc;
using CompanySystem.BLL;
using Microsoft.AspNetCore.Authorization;

namespace CompanySystem.MVC
{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var productsVm = _productManager.GetProducts();
            return View(productsVm);
        }

        [Authorize(Roles = $"{SystemRoles.User},{SystemRoles.Admin}")]
        [HttpGet]
        public IActionResult Details(int id)
        {
            var productReadVm = _productManager.GetProductById(id);
            if (productReadVm == null)
            {
                return RedirectToAction(nameof(Index));
            }
           
            return View(productReadVm);
        }

        [Authorize(Roles = SystemRoles.Admin)]
        [HttpGet]
        public IActionResult Create()
        {
            ProductCreateVM productVm = _productManager.ReturnListCategories_C();
            return View(productVm);
        }

        [Authorize(Roles = SystemRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductCreateVM productVm)
        { 
            if (productVm.Image != null)
            {
                var isImage = ImageHelper.IsImage(productVm.Image.FileName);
                if (!isImage)
                {
                    ModelState.AddModelError("Image", "Invalid file type. Only image files are allowed.");
                }
            }
            
            if (!ModelState.IsValid)
            {
                var productCreateVMWithCategories = _productManager.ReturnListCategories_C();
                productVm.Categories = productCreateVMWithCategories.Categories;
                return View(productVm);
            }

            _productManager.CreateProduct(productVm);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = SystemRoles.Admin)]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productManager.GetProductByIdEdit(id);
            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }
            
            var productEditVMWithCategories = _productManager.ReturnListCategories_E();
            product.Categories = productEditVMWithCategories.Categories;
            return View(product);
        }

        [Authorize(Roles = SystemRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductEditVM productVm)
        {
            if (productVm.Image != null)
            {
                var isImage = ImageHelper.IsImage(productVm.Image.FileName);
                if (!isImage)
                {
                    ModelState.AddModelError("Image", "Invalid file type. Only image files are allowed.");
                }
            }
            
            if (!ModelState.IsValid)
            {
                var productEditVMWithCategories = _productManager.ReturnListCategories_E();
                productVm.Categories = productEditVMWithCategories.Categories;
                return View(productVm);
            }

            var status = _productManager.EditProduct(productVm);
            if (status == 0)
            {
                var productEditVMWithCategories = _productManager.ReturnListCategories_E();
                productVm.Categories = productEditVMWithCategories.Categories;
                return View(productVm);
            }
            
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = SystemRoles.Admin)]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var status = _productManager.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult IsTitleUnique(string title)
        {
            var isUnique = _productManager.TitleExist(title);
            if (isUnique)
            {
                return Json($"Title {title} is already taken.");
            }

            return Json(true);
        }
    }
}






