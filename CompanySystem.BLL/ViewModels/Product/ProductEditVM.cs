using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CompanySystem.BLL

{
    public class ProductEditVM
    {
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        [Required(ErrorMessage = "Title is mandatory")]
        public string Title { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string? Description { get; set; }

        [Required]
        [Range(0, 100000)]
        public decimal Price { get; set; }

        [Required]
        [Range(10, 50)]
        public int Count { get; set; }

        public int CategoryId { get; set; }

        public IFormFile? Image { get; set; }
        //public string CategoryName { get; set; }


        public SelectList? Categories { get; set; }
    }
}
