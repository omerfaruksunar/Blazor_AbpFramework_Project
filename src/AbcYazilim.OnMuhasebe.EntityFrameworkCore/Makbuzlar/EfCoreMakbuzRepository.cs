using AbcYazilim.OnMuhasebe.Commons;
using AbcYazilim.OnMuhasebe.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AbcYazilim.OnMuhasebe.Makbuzlar;
public class EfCoreMakbuzRepository : EfCoreCommonRepository<Makbuz>, IMakbuzRepository
{
	public EfCoreMakbuzRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) 
		: base(dbContextProvider)
	{
	}
}
