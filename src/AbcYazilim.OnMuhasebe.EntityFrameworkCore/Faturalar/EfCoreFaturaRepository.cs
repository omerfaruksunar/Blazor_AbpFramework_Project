﻿using AbcYazilim.OnMuhasebe.Commons;
using AbcYazilim.OnMuhasebe.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace AbcYazilim.OnMuhasebe.Faturalar;
public class EfCoreFaturaRepository : EfCoreCommonRepository<Fatura>, IFaturaRepository
{
	public EfCoreFaturaRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) 
		: base(dbContextProvider)
	{
	}

	public override async Task<IQueryable<Fatura>> WithDetailsAsync()
	{
		return (await GetQueryableAsync())
			.Include(x => x.Cari)
			.Include(x => x.OzelKod1)
			.Include(x => x.OzelKod2)
			.Include(x=>x.FaturaHareketler).ThenInclude(x=>x.Depo)
			.Include(x => x.FaturaHareketler).ThenInclude(x => x.Stok)
											 .ThenInclude(x => x.Birim)
		    .Include(x => x.FaturaHareketler).ThenInclude(x => x.Hizmet)
											 .ThenInclude(x => x.Birim)
		    .Include(x => x.FaturaHareketler).ThenInclude(x => x.Masraf)
											 .ThenInclude(x => x.Birim);

	}
}
