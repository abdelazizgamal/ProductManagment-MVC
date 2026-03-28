namespace CompanySystem.DAL
{
    public class Category
    {
        public int Id { get; set; }
        public required String Name { get; set; }
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();


        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
