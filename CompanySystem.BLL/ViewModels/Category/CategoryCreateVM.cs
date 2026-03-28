using System.ComponentModel.DataAnnotations;

namespace CompanySystem.BLL

{
    public class CategoryCreateVM
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

    }
}
