using AbcYazilim.OnMuhasebe.Depolar;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace AbcYazilim.OnMuhasebe.Parametreler;
public class FirmaParametreAppService : OnMuhasebeAppService, IFirmaParametreAppService
{
	private readonly IFirmaParametreRepository _firmaParametreRepository;
	private readonly FirmaParametreManager _firmaParametreManager;

	public FirmaParametreAppService(IFirmaParametreRepository firmaParametreRepository, FirmaParametreManager firmaParametreManager)
	{
		_firmaParametreRepository = firmaParametreRepository;
		_firmaParametreManager = firmaParametreManager;
	}

	#nullable disable	
	public virtual async Task<SelectFirmaParametreDto> GetAsync(Guid userId)
	{
		
		var entity = await _firmaParametreRepository.GetAsync(x => x.UserId == userId,
			x => x.Sube, x => x.Donem, x => x.Depo);

		if (entity == null) return null;

		return ObjectMapper.Map<FirmaParametre, SelectFirmaParametreDto>(entity);
	}

	//swagger da endpoint olarak görünmesini istemedigimiz icin NonAction
	[NonAction]
	public virtual Task<PagedResultDto<SelectFirmaParametreDto>>
		GetListAsync(FirmaParametreListParameterDto input)
	{
		throw new NotImplementedException();
	}

	public virtual async Task<SelectFirmaParametreDto> CreateAsync(
		CreateFirmaParametreDto input)
	{
		await _firmaParametreManager.CheckCreateAsync(input.SubeId, input.DonemId, input.DepoId);
		var entity = ObjectMapper.Map<CreateFirmaParametreDto, FirmaParametre>(input);
		await _firmaParametreRepository.InsertAsync(entity);
		return ObjectMapper.Map<FirmaParametre, SelectFirmaParametreDto>(entity);
	}

	public virtual async Task<SelectFirmaParametreDto> UpdateAsync(Guid userId,
		UpdateFirmaParametreDto input)
	{
		await _firmaParametreManager.CheckUpdateAsync(input.SubeId, input.DonemId, input.DepoId);
		var entity = await _firmaParametreRepository.GetAsync(userId, x => x.UserId == userId);
		var mappedEntity = ObjectMapper.Map(input, entity);
		await _firmaParametreRepository.UpdateAsync(mappedEntity);
		return ObjectMapper.Map<FirmaParametre, SelectFirmaParametreDto>(mappedEntity);
	}

	[NonAction]
	public async Task<bool> UserAnyAsync(Guid userId)
	{
		return await _firmaParametreRepository.AnyAsync(x => x.UserId == userId);
	}
}
