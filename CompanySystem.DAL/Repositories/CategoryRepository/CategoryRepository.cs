namespace CompanySystem.DAL
{
    public class CategoryRepository :GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context):base(context)
        {
        }
        
    }
}
