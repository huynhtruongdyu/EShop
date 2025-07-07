using EShop.Data.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace EShop.Data
{
    public interface IUnitOfWork : IDisposable
    {
        // Repositories
        ICategoryRepository Categories { get; }

        ICategoryTranslationRepository CategoryTranslations { get; }
        // Save changes

        Task<int> SaveChangesAsync();

        // Transaction support
        Task<IDbContextTransaction> BeginTransactionAsync();

        Task CommitTransactionAsync();

        Task RollbackTransactionAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction? _currentTransaction;

        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<ICategoryTranslationRepository> _categoryTranslationRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_context));
            _categoryTranslationRepository = new Lazy<ICategoryTranslationRepository>(() => new CategoryTranslationRepository(_context));
        }

        public ICategoryRepository Categories => _categoryRepository.Value;
        public ICategoryTranslationRepository CategoryTranslations => _categoryTranslationRepository.Value;

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                return _currentTransaction;
            }
            _currentTransaction = await _context.Database.BeginTransactionAsync();
            return _currentTransaction;
        }

        public async Task CommitTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.CommitAsync();
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }

        public void Dispose()
        {
            _currentTransaction?.Dispose();
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task RollbackTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.RollbackAsync();
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}