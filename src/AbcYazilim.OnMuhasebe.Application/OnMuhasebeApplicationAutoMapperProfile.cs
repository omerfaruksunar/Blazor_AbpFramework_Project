﻿using AbcYazilim.OnMuhasebe.BankaHesaplar;
using AbcYazilim.OnMuhasebe.Bankalar;
using AbcYazilim.OnMuhasebe.BankaSubeler;
using AbcYazilim.OnMuhasebe.Birimler;
using AbcYazilim.OnMuhasebe.Cariler;
using AbcYazilim.OnMuhasebe.Depolar;
using AbcYazilim.OnMuhasebe.Donemler;
using AbcYazilim.OnMuhasebe.FaturaHareketler;
using AbcYazilim.OnMuhasebe.Faturalar;
using AbcYazilim.OnMuhasebe.Hizmetler;
using AbcYazilim.OnMuhasebe.Kasalar;
using AbcYazilim.OnMuhasebe.MakbuzHareketler;
using AbcYazilim.OnMuhasebe.Makbuzlar;
using AbcYazilim.OnMuhasebe.Masraflar;
using AbcYazilim.OnMuhasebe.OzelKodlar;
using AbcYazilim.OnMuhasebe.Parametreler;
using AbcYazilim.OnMuhasebe.Stoklar;
using AbcYazilim.OnMuhasebe.Subeler;
using AutoMapper;
using System.Linq;

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
			.ForMember(x => x.BankaAdi, y => y.MapFrom(z => z.BankaSube.Banka.Ad))
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
		CreateMap<Birim, ListBirimDto>()
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

		//Depo
		CreateMap<Depo, SelectDepoDto>()
			.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
			.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));
		CreateMap<Depo, ListDepoDto>()
			.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
			.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad))
			.ForMember(x => x.Giren, y => y.MapFrom(z => z.FaturaHareketler
				.Where(x => x.Fatura.FaturaTuru == FaturaTuru.Alis).Sum(x => x.Miktar)))
			.ForMember(x => x.Cikan, y => y.MapFrom(z => z.FaturaHareketler
				.Where(x => x.Fatura.FaturaTuru == FaturaTuru.Satis).Sum(x => x.Miktar)));
		CreateMap<CreateDepoDto, Depo>();
		CreateMap<UpdateDepoDto, Depo>();

		//Donem
		CreateMap<Donem, SelectDonemDto>();
		CreateMap<Donem, ListDonemDto>();
		CreateMap<CreateDonemDto, Donem>();
		CreateMap<UpdateDonemDto, Donem>();

		//Fatura
		CreateMap<Fatura, SelectFaturaDto>()
			.ForMember(x => x.CariAdi, y => y.MapFrom(z => z.Cari.Ad))
			.ForMember(x => x.VergiDairesi, y => y.MapFrom(z => z.Cari.VergiDairesi))
			.ForMember(x => x.VergiNo, y => y.MapFrom(z => z.Cari.VergiNo))
			.ForMember(x => x.Adres, y => y.MapFrom(z => z.Cari.Adres))
			.ForMember(x => x.Telefon, y => y.MapFrom(z => z.Cari.Telefon))
			.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
			.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));
		CreateMap<Fatura, ListFaturaDto>()
			.ForMember(x => x.CariAdi, y => y.MapFrom(z => z.Cari.Ad))
			.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
			.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));
		CreateMap<CreateFaturaDto, Fatura>();
		CreateMap<UpdateFaturaDto, Fatura>()
			/*
			 * Sadece uı'dan silinmiş olarak gönderilen hareketlerin isDeleted 
			 * durumlarini true olarak ayarlamis olacak(ignore)
			*/
			.ForMember(x => x.FaturaHareketler, y => y.Ignore());

		//Fatura Hareket
		CreateMap<FaturaHareket, SelectFaturaHareketDto>()
			.ForMember(x => x.StokKodu, y => y.MapFrom(z => z.Stok.Kod))
			.ForMember(x => x.StokAdi, y => y.MapFrom(z => z.Stok.Ad))
			.ForMember(x => x.HizmetKodu, y => y.MapFrom(z => z.Hizmet.Kod))
			.ForMember(x => x.HizmetAdi, y => y.MapFrom(z => z.Hizmet.Ad))
			.ForMember(x => x.MasrafKodu, y => y.MapFrom(z => z.Masraf.Kod))
			.ForMember(x => x.MasrafAdi, y => y.MapFrom(z => z.Masraf.Ad))
			.ForMember(x => x.DepoKodu, y => y.MapFrom(z => z.Depo.Kod))
			.ForMember(x => x.DepoAdi, y => y.MapFrom(z => z.Depo.Ad))

			.ForMember(x => x.BirimAdi, y => y.MapFrom(z => z.Stok != null ?
							z.Stok.Birim.Ad : z.Hizmet != null ? z.Hizmet.Birim.Ad :
							z.Masraf != null ? z.Masraf.Birim.Ad : null))

			.ForMember(x => x.HareketKodu, y => y.MapFrom(z => z.Stok != null ?
							z.Stok.Kod : z.Hizmet != null ? z.Hizmet.Kod :
							z.Masraf != null ? z.Masraf.Kod : null))

			.ForMember(x => x.HareketAdi, y => y.MapFrom(z => z.Stok != null ?
							z.Stok.Ad : z.Hizmet != null ? z.Hizmet.Ad :
							z.Masraf != null ? z.Masraf.Ad : null));
		CreateMap<FaturaHareketDto, FaturaHareket>();

		//Hizmet
		CreateMap<Hizmet, SelectHizmetDto>()
			.ForMember(x => x.BirimAdi, y => y.MapFrom(z => z.Birim.Ad))
			.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
			.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));
		CreateMap<Hizmet, ListHizmetDto>()
			.ForMember(x => x.BirimAdi, y => y.MapFrom(z => z.Birim.Ad))
			.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
			.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad))
			.ForMember(x => x.Giren, y => y.MapFrom(z => z.FaturaHareketler
				.Where(x => x.Fatura.FaturaTuru == FaturaTuru.Alis).Sum(x => x.Miktar)))
			.ForMember(x => x.Cikan, y => y.MapFrom(z => z.FaturaHareketler
				.Where(x => x.Fatura.FaturaTuru == FaturaTuru.Satis).Sum(x => x.Miktar)));
		CreateMap<CreateHizmetDto, Hizmet>();
		CreateMap<UpdateHizmetDto, Hizmet>();

		//Kasa
		CreateMap<Kasa, SelectKasaDto>()
			.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
			.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));
		CreateMap<Kasa, ListKasaDto>()
			.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
			.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad))
			.ForMember(x => x.Borc, y => y.MapFrom(z => z.MakbuzHareketler
				.Where(x => x.BelgeDurumu == BelgeDurumu.TahsilEdildi).Sum(x => x.Tutar)))
			.ForMember(x => x.Alacak, y => y.MapFrom(z => z.MakbuzHareketler
				.Where(x => x.BelgeDurumu == BelgeDurumu.Odendi).Sum(x => x.Tutar)));
		CreateMap<CreateKasaDto, Kasa>();
		CreateMap<UpdateKasaDto, Kasa>();

		//Makbuz
		CreateMap<Makbuz, SelectMakbuzDto>()
			.ForMember(x => x.CariKodu, y => y.MapFrom(z => z.Cari.Kod))
			.ForMember(x => x.CariAdi, y => y.MapFrom(z => z.Cari.Ad))
			.ForMember(x => x.KasaAdi, y => y.MapFrom(z => z.Kasa.Ad))
			.ForMember(x => x.BankaHesapAdi, y => y.MapFrom(z => z.BankaHesap.Ad))
			.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
			.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad))
			.ForMember(x => x.SubeAdi, y => y.MapFrom(z => z.Sube.Ad));
		CreateMap<Makbuz, ListMakbuzDto>()
			.ForMember(x => x.CariAdi, y => y.MapFrom(z => z.Cari.Ad))
			.ForMember(x => x.KasaAdi, y => y.MapFrom(z => z.Kasa.Ad))
			.ForMember(x => x.BankaHesapAdi, y => y.MapFrom(z => z.BankaHesap.Ad))
			.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
			.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));
		CreateMap<CreateMakbuzDto, Makbuz>();
		CreateMap<UpdateMakbuzDto, Makbuz>()
			.ForMember(x => x.MakbuzTuru, y => y.Ignore())
			.ForMember(x => x.MakbuzHareketler, y => y.Ignore());

		//Makbuz Hareket
		CreateMap<MakbuzHareket, SelectMakbuzHareketDto>()
			.ForMember(x => x.CekBankaAdi, y => y.MapFrom(z => z.CekBanka.Ad))
			.ForMember(x => x.CekBankaSubeAdi, y => y.MapFrom(z => z.CekBankaSube.Ad))
			.ForMember(x => x.KasaAdi, y => y.MapFrom(z => z.Kasa.Ad))
			.ForMember(x => x.BankaHesapAdi, y => y.MapFrom(z => z.BankaHesap.Ad));
		CreateMap<MakbuzHareketDto, MakbuzHareket>();

		//Masraf
		CreateMap<Masraf, SelectMasrafDto>()
				.ForMember(x => x.BirimAdi, y => y.MapFrom(z => z.Birim.Ad))
				.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
				.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));

		CreateMap<Masraf, ListMasrafDto>()
			.ForMember(x => x.BirimAdi, y => y.MapFrom(z => z.Birim.Ad))
			.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
			.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad))
			.ForMember(x => x.Giren, y => y.MapFrom(z => z.FaturaHareketler
				.Where(x => x.Fatura.FaturaTuru == FaturaTuru.Alis).Sum(x => x.Miktar)))
			.ForMember(x => x.Cikan, y => y.MapFrom(z => z.FaturaHareketler
				.Where(x => x.Fatura.FaturaTuru == FaturaTuru.Satis).Sum(x => x.Miktar)));

		CreateMap<CreateMasrafDto, Masraf>();
		CreateMap<UpdateMasrafDto, Masraf>();

		//Ozel Kod
		CreateMap<OzelKod, SelectOzelKodDto>();
		CreateMap<OzelKod, ListOzelKodDto>();
		CreateMap<CreateOzelKodDto, OzelKod>();
		CreateMap<UpdateOzelKodDto, OzelKod>();

		//Firma Parametre
		CreateMap<FirmaParametre, SelectFirmaParametreDto>()
				.ForMember(x => x.SubeAdi, y => y.MapFrom(z => z.Sube.Ad))
				.ForMember(x => x.DonemAdi, y => y.MapFrom(z => z.Donem.Ad))
				.ForMember(x => x.DepoAdi, y => y.MapFrom(z => z.Depo.Ad));
		CreateMap<CreateFirmaParametreDto, FirmaParametre>();
		CreateMap<UpdateFirmaParametreDto, FirmaParametre>();

		//Stok
		CreateMap<Stok, SelectStokDto>()
				.ForMember(x => x.BirimAdi, y => y.MapFrom(z => z.Birim.Ad))
				.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
				.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));
		CreateMap<Stok, ListStokDto>()
			.ForMember(x => x.BirimAdi, y => y.MapFrom(z => z.Birim.Ad))
			.ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
			.ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad))
			.ForMember(x => x.Giren, y => y.MapFrom(z => z.FaturaHareketler
				.Where(x => x.Fatura.FaturaTuru == FaturaTuru.Alis).Sum(x => x.Miktar)))
			.ForMember(x => x.Cikan, y => y.MapFrom(z => z.FaturaHareketler
				.Where(x => x.Fatura.FaturaTuru == FaturaTuru.Satis).Sum(x => x.Miktar)));

		CreateMap<CreateStokDto, Stok>();
		CreateMap<UpdateStokDto, Stok>();

		//Sube
		CreateMap<Sube, SelectSubeDto>();
		CreateMap<Sube, ListSubeDto>();
		CreateMap<CreateSubeDto, Sube>();
		CreateMap<UpdateSubeDto, Sube>();
	}
}
