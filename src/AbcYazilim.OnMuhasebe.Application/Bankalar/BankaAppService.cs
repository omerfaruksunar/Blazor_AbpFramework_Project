using AbcYazilim.OnMuhasebe.CommonDtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace AbcYazilim.OnMuhasebe.Bankalar;
public class BankaAppService : OnMuhasebeAppService, IBankaAppService
{
	private readonly IBankaRepository _bankaRepository;
	private readonly BankaManager _bankaManager;

	public BankaAppService(IBankaRepository bankaRepository, BankaManager bankaManager)
	{
		_bankaRepository = bankaRepository;
		_bankaManager = bankaManager;
	}

	//Virtual olması sayesinde override edebiliyoruz.
	public virtual async Task<SelectBankaDto> GetAsync(Guid id)
	{
		/*
		 * predicate kisminda neleri tanımlayacağımıza şu şekilde karar veririz:
		 * banka entity'sine gittigimizde include propertieslerin neler olduguna bakariz
		 * banka icin baktigimizda OzelKod1 ve OzelKod2 İnclude Properties olarak tanimlanmistir yani
		 * public  OzelKod OzelKod1 { get; set; } olarak tanımladigimiz kisim 
		 */
		var entity = await _bankaRepository.GetAsync(id, b => b.Id == id,
			b => b.OzelKod1, b => b.OzelKod2);
		return ObjectMapper.Map<Banka, SelectBankaDto>(entity);
	}
	
	public virtual async Task<PagedResultDto<ListBankaDto>> GetListAsync(BankaListParameterDto input)
	{
		var entity = await _bankaRepository.GetAsync(5);
		var entities = await _bankaRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount,
			/*
			 * predicate kısmının içeriginin ne olacagina BankaListParameterDto'ya
			 * go to definition yaparak bakabiliriz.
			 */
			b => b.Durum == input.Durum,    //predicate
			b => b.Kod, //orderBy
			/*
			 * İncludeProperties kısmının içeriginin ne olacagina Banka.cs'deki nesnelerden ulasiriz
			 * public OzelKod OzelKod1{get;set;} gibi
			 */
			b => b.OzelKod1, b => b.OzelKod2);//include properties
		var totalCount = await _bankaRepository.CountAsync(b => b.Durum == input.Durum);
		return new PagedResultDto<ListBankaDto>(totalCount,
			ObjectMapper.Map<List<Banka>, List<ListBankaDto>>(entities)
			);
	}
	public virtual async Task<SelectBankaDto> CreateAsync(CreateBankaDto input)
	{
		//Manager kullanarak kontrol islemi yapiyoruz.
		await _bankaManager.CheckCreateAsync(input.Kod, input.OzelKod1Id, input.OzelKod2Id);
		/*
		 * Sadece domain katmaninda tanimlamis oldugumuz entityleri db'ye 
		 * Gonderebildigimiz yani Dto'lari gonderemedigimiz icin Mapleme islemi yapiyoruz.
		*/
		/*
		 * Oncelikle UI'dan geleni mapliyoruz ve elimizde bir entity'miz oluyor.
		 *Bunu InsertAsync ile db'ye gönderiyoruz. mapledigimiz data bir id aliyor.
		 *İd alan entitymizi tekrar SelectBankaSubeDto olarak mapliyoruz.
		*/
		var entity = ObjectMapper.Map<CreateBankaDto, Banka>(input);
		await _bankaRepository.InsertAsync(entity);
		return ObjectMapper.Map<Banka, SelectBankaDto>(entity);
	}
	public virtual async Task<SelectBankaDto> UpdateAsync(Guid id, UpdateBankaDto input)
	{
		var entity = await _bankaRepository.GetAsync(id, b => b.Id == id);

		await _bankaManager.CheckUpdateAsync(id, input.Kod, entity, input.OzelKod1Id
			, input.OzelKod2Id);

		var mappedEntity = ObjectMapper.Map(input, entity);
		await _bankaRepository.UpdateAsync(mappedEntity);
		return ObjectMapper.Map<Banka, SelectBankaDto>(mappedEntity);
	}
	public virtual async Task DeleteAsync(Guid id)
	{
		await _bankaManager.CheckDeleteAsync(id);
		/*Hard delete islemi yapmayacak yani databasedeki veriyi silmeyecek saadece
		id'ye sahip olan entity'nin isDeleted property'sini true olarak isaretleyecek.*/
		await _bankaRepository.DeleteAsync(id);
	}
	public virtual async Task<string> GetCodeAsync(CodeParameterDto input)
	{
		return await _bankaRepository.GetCodeAsync(b => b.Kod, b => b.Durum == input.Durum);
	}
}
