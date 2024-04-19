using AbcYazilim.OnMuhasebe.Commons;
using AbcYazilim.OnMuhasebe.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace AbcYazilim.OnMuhasebe.Depolar;
public class EfCoreDepoRepository : EfCoreCommonRepository<Depo>, IDepoRepository
{
	public EfCoreDepoRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) 
		: base(dbContextProvider)
	{
	}

	public override async Task<IQueryable<Depo>> WithDetailsAsync()
	{
		return (await GetQueryableAsync())
			.Include(x => x.OzelKod1)
			.Include(x => x.OzelKod2)
			//Fatura hareketlerin icindeki Faturayı include etmek için ThenInclude kullaniriz.
			.Include(x => x.FaturaHareketler).ThenInclude(x => x.Fatura);
	}
}
