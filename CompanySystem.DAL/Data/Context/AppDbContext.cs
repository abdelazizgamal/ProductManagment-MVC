using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace CompanySystem.DAL

{
    public class AppDbContext: IdentityDbContext<ApplicationUser,ApplicationRole,String>
    {
        public AppDbContext(): base()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public override int SaveChanges()
        {
            AuditLog();
            return base.SaveChanges();
        }
        /*------------------------------------------------------------------*/
        private void AuditLog()
        {
            var dateTime = DateTime.UtcNow;
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = dateTime;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = dateTime;
                }
            }
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connectionString = "Server=.;DataBase=ProductsMangmentDb;Trusted_Connection=true;TrustServerCertificate=true";
        //    optionsBuilder.UseSqlServer(connectionString);
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding data
            // Created date for all records
            var createdDate = new DateTime(2026, 3, 1, 10, 30, 0);


            // Categories Seeding
            var _Categories = new List<Category>()
            {
                new Category() { Id = 1, Name = "Electronics", CreatedAt = createdDate },
                new Category() { Id = 2, Name = "Groceries", CreatedAt = createdDate },
                new Category() { Id = 3, Name = "Home Appliances", CreatedAt = createdDate }
            };


            // Products Seeding
            var _Products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Title = "Samsung 55\" 4K Smart TV",
                    Description = "Ultra HD Smart TV with HDR and built-in streaming apps",
                    Price = 9500,
                    Count = 8,
                    CategoryId = 1,
                    CreatedAt = createdDate,
                    ExpiryDate = null
                },

                new Product()
                {
                    Id = 2,
                    Title = "Apple AirPods Pro",
                    Description = "Wireless earbuds with noise cancellation",
                    Price = 7200,
                    Count = 15,
                    CategoryId = 1,
                    CreatedAt = createdDate,
                    ExpiryDate = null
                },

                new Product()
                {
                    Id = 3,
                    Title = "Nescafe Classic Coffee 200g",
                    Description = "Instant coffee made from premium roasted beans",
                    Price = 180,
                    Count = 40,
                    CategoryId = 2,
                    CreatedAt = createdDate,
                    ExpiryDate = new DateOnly(2027, 1, 10)
                },

                new Product()
                {
                    Id = 4,
                    Title = "Almarai Fresh Milk 1L",
                    Description = "Fresh full-cream milk rich in calcium",
                    Price = 35,
                    Count = 50,
                    CategoryId = 2,
                    CreatedAt = createdDate,
                    ExpiryDate = new DateOnly(2026, 3, 20)
                },

                new Product()
                {
                    Id = 5,
                    Title = "LG Microwave Oven 25L",
                    Description = "Digital microwave oven with grill function",
                    Price = 4200,
                    Count = 6,
                    CategoryId = 3,
                    CreatedAt = createdDate,
                    ExpiryDate = null
                },

                new Product()
                {
                    Id = 6,
                    Title = "Philips Air Fryer",
                    Description = "Healthy air fryer with rapid air technology",
                    Price = 3900,
                    Count = 9,
                    CategoryId = 3,
                    CreatedAt = createdDate,
                    ExpiryDate = null
                },

                new Product()
                {
                    Id = 7,
                    Title = "Oreo Chocolate Biscuits",
                    Description = "Crunchy chocolate biscuits with cream filling",
                    Price = 12,
                    Count = 33,
                    CategoryId = 2,
                    CreatedAt = createdDate,
                    ExpiryDate = new DateOnly(2026, 9, 15)
                }
            };
            modelBuilder.Entity<Category>().HasData(_Categories);
            modelBuilder.Entity<Product>().HasData(_Products);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
    }
}
