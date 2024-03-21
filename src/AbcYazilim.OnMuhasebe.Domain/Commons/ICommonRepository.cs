using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbcYazilim.OnMuhasebe.Commons;
public interface ICommonRepository<TEntity> : IRepository<TEntity, Guid>
	where TEntity : class, IEntity<Guid>
{
	Task<TEntity> GetAsync(object id, Expression<Func<TEntity, bool>> predicate = null,
		params Expression<Func<TEntity, object>>[] includeProperties);

	Task<TEntity> GetAsync( Expression<Func<TEntity, bool>> predicate = null,
		params Expression<Func<TEntity, object>>[] includeProperties);

	Task<TEntity> GetAsync(object id, Expression<Func<TEntity, bool>> predicate = null);

}
