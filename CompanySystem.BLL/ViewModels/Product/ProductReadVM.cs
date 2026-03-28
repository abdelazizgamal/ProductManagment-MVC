namespace CompanySystem.BLL
{
    public class ProductReadVM
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string? ImgeUrl { get; set; }
        public string? Category { get; set; }

       
    }
}
