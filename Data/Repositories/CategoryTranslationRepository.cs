using EShop.Data.Domain;

namespace EShop.Data.Repositories
{
    public interface ICategoryTranslationRepository : IGenericRepository<CategoryTranslation>
    {
        // Define methods for catalog repository operations here
    }

    public class CategoryTranslationRepository(ApplicationDbContext context) : GenericRepository<CategoryTranslation>(context), ICategoryTranslationRepository
    {
    }
}