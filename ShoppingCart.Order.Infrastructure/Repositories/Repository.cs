using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly OrderDbContext _dbContext;

        public Repository(OrderDbContext context)
        {
            _dbContext = context;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public IQueryable<TEntity> GetAllQuerybleAsync()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            try
            {
                await _dbContext.AddAsync(entity);
                SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void UpdateAsync(TEntity entity)
        {
            _dbContext.Update(entity);
            SaveChanges();
        }

        public void DeleteAsync(TEntity entity)
        {
            _dbContext.Remove(entity);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
