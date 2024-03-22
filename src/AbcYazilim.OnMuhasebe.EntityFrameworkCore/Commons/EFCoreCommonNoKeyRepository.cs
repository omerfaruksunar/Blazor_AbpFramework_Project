using AbcYazilim.OnMuhasebe.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;

namespace AbcYazilim.OnMuhasebe.Commons;
public class EFCoreCommonNoKeyRepository<TEntity>: EfCoreRepository<OnMuhasebeDbContext,TEntity>,
	ICommonNoKeyRepository<TEntity> where TEntity : class, IEntity
{
}
