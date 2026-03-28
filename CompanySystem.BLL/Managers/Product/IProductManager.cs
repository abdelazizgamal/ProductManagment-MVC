using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySystem.BLL
{
    public interface IProductManager
    { /*------------------------------------------------------------------*/
        // Get All Products (View Model)
        IEnumerable<ProductReadVM> GetProducts();
        /*------------------------------------------------------------------*/
        // Get Product By Id (View Model)
        ProductReadVM? GetProductById(int id);
        /*------------------------------------------------------------------*/
        // Create Product (View Model)
        ProductCreateVM ReturnListCategories_C();
        /*------------------------------------------------------------------*/
        // Create New Product
        int CreateProduct(ProductCreateVM productCreateVM);
        /*------------------------------------------------------------------*/

        // Edit Product (View Model)
        ProductEditVM ReturnListCategories_E();
        /*------------------------------------------------------------------*/
        // Create New Product
        int EditProduct(ProductEditVM productEditVM);
        /*------------------------------------------------------------------*/
        int DeleteProduct(int id);
        bool TitleExist(string title);
        ProductEditVM? GetProductByIdEdit(int id);
    }
}
