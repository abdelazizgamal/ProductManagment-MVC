namespace CompanySystem.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IProductRepository ProductRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public UnitOfWork(AppDbContext context,
            IProductRepository employeeRepository,
            ICategoryRepository categoryRepository)
        {
            ProductRepository = employeeRepository;
            CategoryRepository = categoryRepository;
            _context = context;
        }

        public int  Save()
        {
           return _context.SaveChanges();
        }
    }
}
