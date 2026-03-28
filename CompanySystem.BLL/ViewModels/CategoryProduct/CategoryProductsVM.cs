
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanySystem.BLL

{
    public class CategoryProductsVM
    {

        public int CategoryId { get; set; }
        public List<SelectListItem>? Catigories{ get; set; }
    }
}
