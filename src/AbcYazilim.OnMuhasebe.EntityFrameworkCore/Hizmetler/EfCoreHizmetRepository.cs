﻿using AbcYazilim.OnMuhasebe.Commons;
using AbcYazilim.OnMuhasebe.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace AbcYazilim.OnMuhasebe.Hizmetler;
public class EfCoreHizmetRepository : EfCoreCommonRepository<Hizmet>, IHizmetRepository
{
	public EfCoreHizmetRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) 
		: base(dbContextProvider)
	{
	}

	public override async Task<IQueryable<Hizmet>> WithDetailsAsync()
	{
		return (await GetQueryableAsync())
			.Include(x => x.Birim)
			.Include(x => x.OzelKod1)
			.Include(x => x.OzelKod2)
			.Include(x => x.FaturaHareketler).ThenInclude(x => x.Fatura);
	}
}
