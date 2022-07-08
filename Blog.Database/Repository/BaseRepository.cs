using System.Linq.Expressions;
using BlogCommon;
using Microsoft.EntityFrameworkCore;

namespace Blog.Database;

public abstract class BaseRepository<TModel> where TModel : BaseModel
{
    protected readonly AppDbContext AppDbContext;

    public BaseRepository(AppDbContext appDbContext) { AppDbContext = appDbContext; }

    public async Task CreateAsync(TModel item)
    {
        await AppDbContext.Set<TModel>().AddAsync(item);
        await AppDbContext.SaveChangesAsync();
    } 

    public async Task CreateRangeAsync(IEnumerable<TModel> items)
        => await AppDbContext.Set<TModel>().AddRangeAsync(items);

    public async Task Delete(TModel item)
        => AppDbContext.Set<TModel>().Remove(item);

    public async Task<TModel> GetOneAsync(Expression<Func<TModel, bool>> predicate)
        => await AppDbContext.Set<TModel>().AsNoTracking().FirstOrDefaultAsync(predicate);
    
    public IQueryable<TModel> FindByCondition(Expression<Func<TModel, bool>> expression,
        bool trackChanges)
        => !trackChanges
            ? AppDbContext.Set<TModel>()
                .Where(expression)
                .AsNoTracking()
            : AppDbContext.Set<TModel>()
                .Where(expression);
}