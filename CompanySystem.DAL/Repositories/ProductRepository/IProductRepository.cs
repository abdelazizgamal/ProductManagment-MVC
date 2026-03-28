namespace CompanySystem.DAL
{
    public interface IProductRepository: IGenericRepository<Product>
    {
  
        public bool TitleCheck(string title);

        IEnumerable<Product> GetAllWithCategory();
        /*------------------------------------------------------------------*/
        Product? GetByIdWithCategory(int ProductID);
        /*------------------------------------------------------------------*/
    }
}
