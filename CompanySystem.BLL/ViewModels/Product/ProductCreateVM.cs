using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CompanySystem.BLL

{
    public class ProductCreateVM
    {
        [MinLength(3)]
        [MaxLength(20)]
        [Required(ErrorMessage = "Title is mandatory")]
        [Remote(action:"IsTitleUnique",controller:"Product", ErrorMessage ="Title is already taken!!.")]
        public  string Title { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string? Description { get; set; }

        [Required]
        [Range(0, 100000)]
        public decimal Price { get; set; }

        [Required]
        [Range(10, 50)]
        public int Count { get; set; }
        //[DateInFuture]
        [DataType(DataType.Date)]
        [IsValidExpiryDate(2)]
        public DateOnly? ExpiryDate { get; set; }

        [Required]
        public IFormFile? Image { get; set; }

        public int CategoryId { get; set; }



        public SelectList? Categories { get; set; }
    }
}
