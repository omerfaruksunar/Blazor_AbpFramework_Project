using AbcYazilim.OnMuhasebe.BankaHesaplar;
using AbcYazilim.OnMuhasebe.Bankalar;
using AbcYazilim.OnMuhasebe.BankaSubeler;
using AbcYazilim.OnMuhasebe.Birimler;
using AbcYazilim.OnMuhasebe.Cariler;
using AutoMapper;

namespace AbcYazilim.OnMuhasebe;

public class OnMuhasebeApplicationAutoMapperProfile : Profile
{
	public OnMuhasebeApplicationAutoMapperProfile()
	{
		//Banka
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

		//BankaSube
		CreateMap<BankaSube, SelectBankaSubeDto>()
			//.ForMember'lı alanda nelerin tanimlanacagini bilmek icin SelectBankaSubeDto icerigindeki propertylere bak.
			//BankaSube'nin propertylerine de bak.
			.ForMember(x => x.BankaAdi, y => y.MapFrom(z => z.Banka.Ad))
			.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
			.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));

		CreateMap<BankaSube, ListBankaSubeDto>()
			.ForMember(x => x.BankaAdi, y => y.MapFrom(z => z.Banka.Ad))
			.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
			.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));
		CreateMap<CreateBankaSubeDto, BankaSube>();
		CreateMap<UpdateBankaSubeDto, BankaSube>();

		//BankaHesap
		CreateMap<BankaHesap, SelectBankaHesapDto>()
			.ForMember(x => x.BankaId, y => y.MapFrom(z => z.BankaSube.Banka.Id))
			.ForMember(x=>x.BankaAdi,y=>y.MapFrom(z=>z.BankaSube.Banka.Ad))
			.ForMember(x => x.BankaSubeAdi, y => y.MapFrom(z => z.BankaSube.Ad))
			.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
			.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));
		CreateMap<BankaHesap, ListBankaHesapDto>()
			.ForMember(x => x.BankaAdi, y => y.MapFrom(z => z.BankaSube.Banka.Ad))
			.ForMember(x => x.BankaSubeAdi, y => y.MapFrom(z => z.BankaSube.Ad))
			.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
			.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad)); 
		CreateMap<CreateBankaHesapDto, BankaHesap>();
		CreateMap<UpdateBankaHesapDto, BankaHesap>();

		//Birim
		CreateMap<Birim, SelectBirimDto>()
			.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
			.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));
		CreateMap<Birim,ListBirimDto>()
			.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
			.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));
		CreateMap<CreateBirimDto, Birim>();
		CreateMap<UpdateBirimDto, Birim>();

		//Cari
		CreateMap<Cari, SelectCariDto>()
			.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
			.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));
		CreateMap<Cari, ListCariDto>()
			.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
			.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));
		CreateMap<CreateCariDto, Cari>();
		CreateMap<UpdateCariDto, Cari>();
	}
}
