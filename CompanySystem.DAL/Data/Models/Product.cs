namespace CompanySystem.DAL
{
    public class Product: IAuditableEntity
    {
        public int Id { get; set; }
        public required String Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public DateOnly? ExpiryDate { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get ; set; }
    }
}
