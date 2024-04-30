using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace AbcYazilim.OnMuhasebe.Commons;
public interface ICommonRepository<TEntity> : IRepository<TEntity, Guid>
	where TEntity : class, IEntity<Guid>
{
	Task<TEntity> GetAsync(object id, Expression<Func<TEntity, bool>> predicate = null,
		params Expression<Func<TEntity, object>>[] includeProperties);

	Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
		params Expression<Func<TEntity, object>>[] includeProperties);

	Task<TEntity> GetAsync(object id, Expression<Func<TEntity, bool>> predicate = null);

	//Kac adet kayit alicaksak bize sirali olarak getiren metod.
	Task<List<TEntity>> GetPagedListAsync<TKey>(int skipCount, int maxResultCount,
		Expression<Func<TEntity, bool>> predicate = null,
		Expression<Func<TEntity,TKey>> orderBy=null,
		params Expression<Func<TEntity, object>>[] includeProperties);

	Task<List<TEntity>> GetPagedListAsync<TKey>(int skipCount, int maxResultCount,
		Expression<Func<TEntity, bool>> predicate = null,
		Expression<Func<TEntity, TKey>> orderBy = null);

	//Kac adet kayit alicaksak bize tersten sirali olarak getiren metod.
	Task<List<TEntity>> GetPagedLastListAsync<TKey>(int skipCount, int maxResultCount,
		Expression<Func<TEntity, bool>> predicate = null,
		Expression<Func<TEntity, TKey>> orderBy = null,
		params Expression<Func<TEntity, object>>[] includeProperties);

	//Kodumuzun otomatik olarak dolmasını saglayacak metod.
	Task<string>GetCodeAsync(Expression<Func<TEntity,string>> propertySelector,
		Expression<Func<TEntity,bool>> predicate = null);

	//Db'den bizim verecegimiz storeprocedure'ü calistiracak.
	Task<IList<TEntity>> FromSqlRawAsync(string sql, params object [] parameters);

	Task<bool> AnyAsync (Expression<Func<TEntity, bool>> predicate = null);
}