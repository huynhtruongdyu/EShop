using Dapper;
using EShop.Data.Domain;
using EShop.DTOs;

namespace EShop.Services
{
    public interface ICatalogService
    {
        Task<IEnumerable<CategoryDTO>> GetSFCategoriesAsync(CancellationToken cancellationToken = default);
    }

    public class CatalogService(IUnitOfWork unitOfWork, IDbConnection dbConnection) : ICatalogService
    {
        public async Task<IEnumerable<CategoryDTO>> GetSFCategoriesAsync(CancellationToken cancellationToken = default)
        {
            var sql = """
                    SELECT c.Id, ct.Name, ct.[Description]
                    FROM CategoryTranslations ct JOIN Categories c on ct.CategoryId = c.Id
                """;
            var categories = await dbConnection.QueryAsync<CategoryDTO>(sql) ?? [];
            return categories;
        }
    }
}