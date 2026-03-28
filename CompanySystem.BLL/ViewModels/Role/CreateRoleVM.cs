using System.ComponentModel.DataAnnotations;

namespace CompanySystem.BLL
{
    public class CreateRoleVM
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string RoleName { get; set; }
    }
}
