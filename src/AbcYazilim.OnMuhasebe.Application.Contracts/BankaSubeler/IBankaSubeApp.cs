using AbcYazilim.OnMuhasebe.Services;

namespace AbcYazilim.OnMuhasebe.BankaSubeler;
public interface IBankaSubeApp : ICrudAppService<SelectBankaSubeDto, ListBankaSubeDto,
	BankaSubeListParameterDto, CreateBankaSubeDto, UpdateBankaSubeDto,
	BankaSubeCodeParameterDto>
{
}
