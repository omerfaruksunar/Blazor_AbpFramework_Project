using AbcYazilim.OnMuhasebe.Bankalar;
using AutoMapper;

namespace AbcYazilim.OnMuhasebe;

public class OnMuhasebeApplicationAutoMapperProfile : Profile
{
	public OnMuhasebeApplicationAutoMapperProfile()
	{
		//Olusturdugumuz maplemeleri buraya ekliyoruz.
		CreateMap<Banka,SelectBankaDto>();
		CreateMap<Banka,ListBankaDto>();
		CreateMap<CreateBankaDto, Banka>();
		CreateMap<UpdateBankaDto, Banka>();	
	}
}
