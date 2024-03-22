using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbcYazilim.OnMuhasebe.Commons;

//Id zorunlulugu olmadan ekleme yapmak icin.
public interface ICommonNoKeyRepository<TEntity>:IRepository<TEntity>
where TEntity : class, IEntity
{
	Task<TEntity> FromSqlRawSingleAsync(string sql,params object[] parameters);
	Task<IList<TEntity>> FromSqlRawAsync(string sql, params object[] parameters);
}