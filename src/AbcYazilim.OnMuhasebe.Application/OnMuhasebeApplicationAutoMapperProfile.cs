using AbcYazilim.OnMuhasebe.Bankalar;
using AutoMapper;

namespace AbcYazilim.OnMuhasebe;

public class OnMuhasebeApplicationAutoMapperProfile : Profile
{
	public OnMuhasebeApplicationAutoMapperProfile()
	{
		//Olusturdugumuz maplemeleri buraya ekliyoruz.
		CreateMap<Banka, SelectBankaDto>()
			//Ozelkodlarin id leriyle birlikte adlarini da alabilmemiz icin yazdik.
			.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
			.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));

		CreateMap<Banka, ListBankaDto>()
			.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
			.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));
		CreateMap<CreateBankaDto, Banka>();
		CreateMap<UpdateBankaDto, Banka>();
	}
}
