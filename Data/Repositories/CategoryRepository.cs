using EShop.Data.Domain;

namespace EShop.Data.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        // Define methods for Category repository operations here
    }

    public class CategoryRepository(ApplicationDbContext context) : GenericRepository<Category>(context), ICategoryRepository
    {
    }
}