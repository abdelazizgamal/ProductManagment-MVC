using System.ComponentModel.DataAnnotations;

namespace CompanySystem.BLL

{
    public class CategoryEditVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3)]

        public string Name { get; set; }
    }
}
