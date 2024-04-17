using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
namespace AbcYazilim.OnMuhasebe.BankaSubeler;
public class BankaSubeAppService : OnMuhasebeAppService, IBankaSubeAppService
{
	private readonly IBankaSubeRepository _bankaSubeRepository;
	private readonly BankaSubeManager _bankaSubeManager;

	public BankaSubeAppService(IBankaSubeRepository bankaSubeRepository, 
		BankaSubeManager bankaSubeManager)
	{
		_bankaSubeRepository = bankaSubeRepository;
		_bankaSubeManager = bankaSubeManager;
	}

	public virtual async Task<SelectBankaSubeDto> GetAsync(Guid id)
	{
		var entity = await _bankaSubeRepository.GetAsync(id, bs => bs.Id == id,
			x => x.Banka, x => x.OzelKod1, x => x.OzelKod2);

		return ObjectMapper.Map<BankaSube, SelectBankaSubeDto>(entity);
	}

	public virtual async Task<PagedResultDto<ListBankaSubeDto>> GetListAsync(
		BankaSubeListParameterDto input)
	{
		var entitities = await _bankaSubeRepository.GetPagedLastListAsync(input.SkipCount,
			input.MaxResultCount,
			x => x.BankaId == input.BankaId && x.Durum == input.Durum,
			x => x.Kod,
			x => x.Banka, x => x.OzelKod1, x => x.OzelKod2);
		var totalCount = await _bankaSubeRepository.CountAsync(x =>
			x.BankaId == input.BankaId && x.Durum == input.Durum);

		return new PagedResultDto<ListBankaSubeDto>(
			totalCount,
			ObjectMapper.Map<List<BankaSube>, List<ListBankaSubeDto>>(entitities)
			);
	}
	public async Task<SelectBankaSubeDto> CreateAsync(CreateBankaSubeDto input)
	{
		//Manager islemleri
		await _bankaSubeManager.CheckCreateAsync(input.Kod, input.BankaId,
												 input.OzelKod1Id, input.OzelKod2Id);
		//Oncelikle UI'dan geleni mapliyoruz ve elimizde bir entity'miz oluyor.
		//Bunu InsertAsync ile db'ye gönderiyoruz. mapledigimiz data bir id aliyor.
		//İd alan entitymizi tekrar SelectBankaSubeDto olarak mapliyoruz.
		var entity = ObjectMapper.Map<CreateBankaSubeDto, BankaSube>(input);
		await _bankaSubeRepository.InsertAsync(entity);
		return ObjectMapper.Map<BankaSube, SelectBankaSubeDto>(entity);
	}

	public virtual async Task<SelectBankaSubeDto> UpdateAsync(Guid id, UpdateBankaSubeDto input)
	{
		var entity = await _bankaSubeRepository.GetAsync(id, bs => bs.Id == id);

		await _bankaSubeManager.CheckUpdateAsync(id, input.Kod, entity, 
												input.OzelKod1Id, input.OzelKod2Id);

		var mappedEntity = ObjectMapper.Map(input, entity);
		await _bankaSubeRepository.UpdateAsync(mappedEntity);
		return ObjectMapper.Map<BankaSube, SelectBankaSubeDto>(mappedEntity);
	}
	public virtual async Task DeleteAsync(Guid id)
	{
		await _bankaSubeManager.CheckDeleteAsync(id);
		await _bankaSubeRepository.DeleteAsync(id);
	}

	public virtual async Task<string> GetCodeAsync(BankaSubeCodeParameterDto input)
	{
		return await _bankaSubeRepository.GetCodeAsync(x => x.Kod,
			x => x.BankaId == input.BankaId && x.Durum == input.Durum);
	}
}
