using CompanySystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySystem.BLL
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<CategoryReadVM> GetCategories()
        {
            return _unitOfWork.CategoryRepository.GetAll()
                    .Select(c => new CategoryReadVM
                    {
                        Id = c.Id,
                        Name = c.Name
                    });
        }
        public CategoryReadVM? GetCategoryById(int id)
        {
            var categoryReadVm = _unitOfWork.CategoryRepository.GetById(id);
            if (categoryReadVm == null) 
            { return null; }

            return new CategoryReadVM {Id = categoryReadVm.Id, Name = categoryReadVm.Name };
        }
        public int CreateCategory(CategoryCreateVM categoryCreateVM)
        {
            var categoryCreate = new Category
            {
                Name = categoryCreateVM.Name
            };
            _unitOfWork.CategoryRepository.Insert(categoryCreate);
            return _unitOfWork.Save();
        }
        public CategoryEditVM? GetCategoryByIdEdit(int id)
        {
            var categoryEditVM = _unitOfWork.CategoryRepository.GetById(id);
            if (categoryEditVM == null)
            { return null; }

            return new CategoryEditVM { Id = categoryEditVM.Id, Name = categoryEditVM.Name };
        }
        public int EditCategory(CategoryEditVM categoryEditVM)
        {
            var category = _unitOfWork.CategoryRepository.GetById(categoryEditVM.Id);
            if (category == null)
                return 0;
            category.Name = categoryEditVM.Name;
            return _unitOfWork.Save();
        }

        public int DeleteCategory(int id)
        {
            var category = _unitOfWork.CategoryRepository.GetById(id);
            if (category == null)
                return 0;
            _unitOfWork.CategoryRepository.Delete(category);
            return _unitOfWork.Save();
        }



    }
}
