namespace SportsStore.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private readonly StoreDbContext context;
        public EFStoreRepository(StoreDbContext ctx) => context = ctx;
        public IQueryable<Product> Products => context.Products;
    }
}