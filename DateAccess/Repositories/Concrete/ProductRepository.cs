namespace DateAccess.Repositories.Concrete
{
	public class ProductRepository : EfBaseRepository<Product, AppDbContext>, IProductRepository
	{
		public ProductRepository(AppDbContext context) : base(context)
		{
		}
	}
}
