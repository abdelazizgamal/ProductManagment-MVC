using Microsoft.EntityFrameworkCore;

namespace CompanySystem.DAL
{
    public class ProductRepository : GenericRepository<Product>,IProductRepository
    {
        public ProductRepository(AppDbContext context):base(context) 
        {
        }
        public IEnumerable<Product> GetAllWithCategory()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }

        public Product? GetByIdWithCategory(int ProductID)
        {
            return _context.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == ProductID);
        }

        public bool TitleCheck(string title) { 
            return _context.Products.Any(p=> p.Title == title);
        }

    }
}
