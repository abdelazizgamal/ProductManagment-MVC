using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySystem.BLL
{
    public interface ICategoryManager
    {
 
        IEnumerable<CategoryReadVM> GetCategories();
        /*------------------------------------------------------------------*/
   
        CategoryReadVM? GetCategoryById(int id);
        /*------------------------------------------------------------------*/
        
        int CreateCategory(CategoryCreateVM categoryCreateVM);
        /*------------------------------------------------------------------*/

        int EditCategory(CategoryEditVM categoryEditVM);
        /*------------------------------------------------------------------*/
        int DeleteCategory(int id);
        CategoryEditVM? GetCategoryByIdEdit(int id);
    }
}
