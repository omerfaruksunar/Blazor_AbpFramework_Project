using AbcYazilim.OnMuhasebe.Commons;
using AbcYazilim.OnMuhasebe.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AbcYazilim.OnMuhasebe.Hizmetler;
public class EfCoreHizmetRepository : EfCoreCommonRepository<Hizmet>, IHizmetRepository
{
	public EfCoreHizmetRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) 
		: base(dbContextProvider)
	{
	}
}
