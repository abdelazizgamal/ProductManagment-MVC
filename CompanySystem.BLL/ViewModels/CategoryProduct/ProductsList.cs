using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanySystem.BLL
{
    public class ProductsList
    {
        public int Id { get; set; }
        public List<SelectListItem> prodList { get; set; }
    }
}
