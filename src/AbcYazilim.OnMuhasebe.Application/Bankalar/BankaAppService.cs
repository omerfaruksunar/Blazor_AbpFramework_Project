using AbcYazilim.OnMuhasebe.CommonDtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace AbcYazilim.OnMuhasebe.Bankalar;
public class BankaAppService : OnMuhasebeAppService, IBankaAppService
{
	private readonly IBankaRepository _bankaRepository;

	public BankaAppService(IBankaRepository bankaRepository)
	{
		_bankaRepository = bankaRepository;
	}

	public async Task<SelectBankaDto> GetAsync(Guid id)
	{
		var entity = await _bankaRepository.GetAsync(id,b=>b.Id==id );
		return ObjectMapper.Map<Banka,SelectBankaDto>(entity);
	}
	public Task<PagedResultDto<ListBankaDto>> GetListAsync(BankaListParameterDto input)
	{
		throw new NotImplementedException();
	}
	public async Task<SelectBankaDto> CreateAsync(CreateBankaDto input)
	{
		//Sadece domain katmaninda tanimlamis oldugumuz entityleri db'ye 
		//Gonderebildigimiz yani Dto'lari gonderemedigimiz icin Mapleme islemi yapiyoruz.
		var entity = ObjectMapper.Map<CreateBankaDto, Banka>(input);
		await _bankaRepository.InsertAsync(entity);
		return ObjectMapper.Map<Banka,SelectBankaDto>(entity);
	}
	public Task<SelectBankaDto> UpdateAsync(Guid id, UpdateBankaDto input)
	{
		throw new NotImplementedException();
	}
	public Task DeleteAsync(Guid id)
	{
		throw new NotImplementedException();
	}
	public Task<string> GetCodeAsync(CodeParameterDto getCodeInput)
	{
		throw new NotImplementedException();
	}
}
