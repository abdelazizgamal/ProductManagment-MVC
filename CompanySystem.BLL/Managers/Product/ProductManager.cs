using CompanySystem.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanySystem.BLL
{
    public class ProductManager : IProductManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<ProductReadVM> GetProducts()
        {
            return _unitOfWork.ProductRepository.GetAllWithCategory()
                .Select(p => new ProductReadVM
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Price = p.Price,
                    Count = p.Count,
                    Category = p.Category.Name,
                    ImgeUrl = p.Image,

                });
        }

        public ProductReadVM? GetProductById(int id)
        {
            var p = _unitOfWork.ProductRepository.GetByIdWithCategory(id);
            if (p == null)
                return null;


            var productReadVM = new ProductReadVM
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Price = p.Price,
                Count = p.Count,
                Category = p.Category.Name,
                ImgeUrl = p.Image,

            };
            return productReadVM;
        }


        public ProductCreateVM ReturnListCategories_C()
        {
            var categories = _unitOfWork.CategoryRepository.GetAll().ToList();
            var Prod = new ProductCreateVM
            {
                Categories = new SelectList(categories, "Id", "Name")
            };
            return Prod;
        }
        public int CreateProduct(ProductCreateVM productCreateVM)
        {
            var imageName = ImageHelper.SaveImage(productCreateVM.Image!);

            var p = new Product
            {
                Title = productCreateVM.Title,
                Description = productCreateVM.Description,
                Price = productCreateVM.Price,
                Count = productCreateVM.Count,
                CategoryId = productCreateVM.CategoryId,
                Image = imageName,
            };

            _unitOfWork.ProductRepository.Insert(p);
            return _unitOfWork.Save();
        }

        public ProductEditVM ReturnListCategories_E()
        {
            var categories = _unitOfWork.CategoryRepository.GetAll().ToList();
            var Prod = new ProductEditVM
            {

                Categories = new SelectList(categories, "Id", "Name")
            };
            return Prod;
        }

        public ProductEditVM? GetProductByIdEdit(int id)
        {
            var p = _unitOfWork.ProductRepository.GetByIdWithCategory(id);
            if (p == null)
                return null;


            var ProductEditVM = new ProductEditVM
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Price = p.Price,
                Count = p.Count,
                CategoryId = p.CategoryId,
            };
            return ProductEditVM;
        }

        public int EditProduct(ProductEditVM productEditVM)
        {
            var productUpdate = _unitOfWork.ProductRepository.GetById(productEditVM.Id);

            if (productUpdate == null)
            {
                return 0;
            }



            productUpdate.Title = productEditVM.Title;
            productUpdate.Description = productEditVM.Description;
            productUpdate.Price = productEditVM.Price;
            productUpdate.Count = productEditVM.Count;
            productUpdate.CategoryId = productEditVM.CategoryId;
           
            if (productEditVM.Image != null)
            {
                var imageName = ImageHelper.SaveImage(productEditVM.Image);
                productUpdate.Image = imageName;

            }

            return _unitOfWork.Save();
        }
        public int DeleteProduct(int productId) {
            var productDelete = _unitOfWork.ProductRepository.GetById(productId);

            if (productDelete == null)
            {
                return 0;
            }
            _unitOfWork.ProductRepository.Delete(productDelete);
            return _unitOfWork.Save();
        }

        public bool TitleExist(string title) {
            return _unitOfWork.ProductRepository.TitleCheck(title);
        }


    }
}
