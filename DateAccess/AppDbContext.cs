namespace DateAccess
{
	public class AppDbContext:IdentityDbContext<AppUser>
	{
        public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt) 
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
