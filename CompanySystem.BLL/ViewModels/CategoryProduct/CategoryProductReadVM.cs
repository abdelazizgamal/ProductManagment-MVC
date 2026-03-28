namespace CompanySystem.BLL
{
    public class CategoryProductReadVM
    {
        public int Id { get; set; }
        public required String Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public String? Category{ get; set; }
    }
}
