using AbcYazilim.OnMuhasebe.BankaHesaplar;
using AbcYazilim.OnMuhasebe.Bankalar;
using AbcYazilim.OnMuhasebe.BankaSubeler;
using AbcYazilim.OnMuhasebe.Birimler;
using AbcYazilim.OnMuhasebe.Cariler;
using AbcYazilim.OnMuhasebe.Consts;
using AbcYazilim.OnMuhasebe.Depolar;
using AbcYazilim.OnMuhasebe.Donemler;
using AbcYazilim.OnMuhasebe.Faturalar;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace AbcYazilim.OnMuhasebe.Configurations;
public static class OnMuhasebeDbContextModelBuilderExtensions
{
	public static void Configure(this ModelBuilder builder)
	{
		builder.Entity<Banka>(b =>
		{
			b.ToTable(OnMuhasebeConsts.DbTablePrefix + "Bankalar", OnMuhasebeConsts.DbSchema);
			b.ConfigureByConvention();

			//properties

			//indexs

			//relations

		});
	}

	public static void ConfigureBanka(this ModelBuilder builder)
	{
		builder.Entity<Banka>(b =>
		{
			b.ToTable(OnMuhasebeConsts.DbTablePrefix + "Bankalar", OnMuhasebeConsts.DbSchema);
			b.ConfigureByConvention();

			//properties
			b.Property(x => x.Kod)
				.IsRequired()
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxKodLength);

			b.Property(x => x.Ad)
				.IsRequired()
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxAdLength);

			b.Property(x => x.OzelKod1Id)
				.HasColumnType(SqlDbType.UniqueIdentifier.ToString());

			b.Property(x => x.OzelKod2Id)
				.HasColumnType(SqlDbType.UniqueIdentifier.ToString());

			b.Property(x => x.Aciklama)
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxAciklamaLength);

			b.Property(x => x.Durum)
				.HasColumnType(SqlDbType.Bit.ToString());

			//indexs
			b.HasIndex(x => x.Kod);

			//relations
			b.HasOne(x => x.OzelKod1)
				.WithMany(x => x.OzelKod1Bankalar)
				.OnDelete(DeleteBehavior.NoAction);

			b.HasOne(x => x.OzelKod2)
				.WithMany(x => x.OzelKod2Bankalar)
				.OnDelete(DeleteBehavior.NoAction);
		});
	}
	public static void ConfigureBankaSube(this ModelBuilder builder)
	{
		builder.Entity<BankaSube>(b =>
		{
			b.ToTable(OnMuhasebeConsts.DbTablePrefix + "BankaSubeler", OnMuhasebeConsts.DbSchema);
			b.ConfigureByConvention();

			//properties
			b.Property(x => x.Kod)
				.IsRequired()
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxKodLength);

			b.Property(x => x.Ad)
				.IsRequired()
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxAdLength);

			b.Property(x => x.BankaId)
				.IsRequired()
				.HasColumnType(SqlDbType.UniqueIdentifier.ToString());

			b.Property(x => x.OzelKod1Id)
				.HasColumnType(SqlDbType.UniqueIdentifier.ToString());

			b.Property(x => x.OzelKod2Id)
				.HasColumnType(SqlDbType.UniqueIdentifier.ToString());

			b.Property(x => x.Aciklama)
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxAciklamaLength);

			b.Property(x => x.Durum)
				.HasColumnType(SqlDbType.Bit.ToString());
			//indexs
			b.HasIndex(x => x.Kod);
			//relations
			b.HasOne(x => x.Banka)
				.WithMany(x => x.BankaSubeler)
				.OnDelete(DeleteBehavior.Cascade);

			b.HasOne(x => x.OzelKod1)
				.WithMany(x => x.OzelKod1BankaSubeler)
				.OnDelete(DeleteBehavior.NoAction);

			b.HasOne(x => x.OzelKod2)
				.WithMany(x => x.OzelKod2BankaSubeler)
				.OnDelete(DeleteBehavior.NoAction);
		});
	}
	public static void ConfigureBankaHesap(this ModelBuilder builder)
	{
		builder.Entity<BankaHesap>(b =>
		{
			b.ToTable(OnMuhasebeConsts.DbTablePrefix + "BankaHesaplar", OnMuhasebeConsts.DbSchema);
			b.ConfigureByConvention();

			//properties
			b.Property(x => x.Kod)
				.IsRequired()
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxKodLength);

			b.Property(x => x.Ad)
				.IsRequired()
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxAdLength);

			b.Property(x => x.HesapTuru)
				.IsRequired()
				.HasColumnType(SqlDbType.TinyInt.ToString());

			b.Property(x => x.HesapNo)
				.IsRequired()
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(BankaHesapConsts.MaxIbanNoLength);

			b.Property(x => x.IbanNo)
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(BankaHesapConsts.MaxIbanNoLength);

			b.Property(x => x.BankaSubeId)
				.IsRequired()
				.HasColumnType(SqlDbType.UniqueIdentifier.ToString());

			b.Property(x => x.OzelKod1Id)
				.HasColumnType(SqlDbType.UniqueIdentifier.ToString());

			b.Property(x => x.OzelKod2Id)
				.HasColumnType(SqlDbType.UniqueIdentifier.ToString());

			b.Property(x => x.SubeId)
				.IsRequired()
				.HasColumnType(SqlDbType.UniqueIdentifier.ToString());

			b.Property(x => x.Aciklama)
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxAciklamaLength);

			b.Property(x => x.Durum)
				.HasColumnType(SqlDbType.Bit.ToString());

			//indexs
			b.HasIndex(x => x.Kod);

			//relations
			b.HasOne(x => x.BankaSube)
				.WithMany(x=> x.BankaHesaplar)
				.OnDelete(DeleteBehavior.Cascade);

			b.HasOne(x => x.OzelKod1)
				.WithMany(x => x.OzelKod1BankaHesaplar)
				.OnDelete(DeleteBehavior.NoAction);

			b.HasOne(x => x.OzelKod2)
				.WithMany(x => x.OzelKod2BankaHesaplar)
				.OnDelete(DeleteBehavior.NoAction);

			b.HasOne(x => x.Sube)
				.WithMany(x => x.BankaHesaplar)
				.OnDelete(DeleteBehavior.Cascade);
		});
	}
	public static void ConfigureBirim(this ModelBuilder builder)
	{
		builder.Entity<Birim>(b =>
		{
			b.ToTable(OnMuhasebeConsts.DbTablePrefix + "Birimler", OnMuhasebeConsts.DbSchema);
			b.ConfigureByConvention();

			//properties
			b.Property(x => x.Kod)
				.IsRequired()
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxKodLength);

			b.Property(x => x.Ad)
				.IsRequired()
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxAdLength);

			b.Property(x => x.OzelKod1Id)
				.HasColumnType(SqlDbType.UniqueIdentifier.ToString());

			b.Property(x => x.OzelKod2Id)
				.HasColumnType(SqlDbType.UniqueIdentifier.ToString());

			b.Property(x => x.Aciklama)
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxAciklamaLength);

			b.Property(x => x.Durum)
				.HasColumnType(SqlDbType.Bit.ToString());

			//indexs
			b.HasIndex(x => x.Kod);
			
			//relations
			b.HasOne(x => x.OzelKod1)
				.WithMany(x => x.OzelKod1Birimler)
				.OnDelete(DeleteBehavior.NoAction);

			b.HasOne(x => x.OzelKod2)
				.WithMany(x => x.OzelKod2Birimler)
				.OnDelete(DeleteBehavior.NoAction);
		});
	}
	public static void ConfigureCari(this ModelBuilder builder)
	{
		builder.Entity<Cari>(b =>
		{
			b.ToTable(OnMuhasebeConsts.DbTablePrefix + "Cariler", OnMuhasebeConsts.DbSchema);
			b.ConfigureByConvention();

			//properties
			b.Property(x => x.Kod)
				.IsRequired()
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxKodLength);

			b.Property(x => x.Ad)
				.IsRequired()
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxAdLength);

			b.Property(x => x.VergiDairesi)
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(CariConsts.MaxVergiDairesiLength);

			b.Property(x => x.VergiNo)
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(CariConsts.MaxVergiNoLength);

			b.Property(x => x.Telefon)
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxTelefonLength);

			b.Property(x => x.Adres)
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxAdresLength);

			b.Property(x => x.OzelKod1)
				.HasColumnType(SqlDbType.UniqueIdentifier.ToString());

			b.Property(x => x.OzelKod2)
				.HasColumnType(SqlDbType.UniqueIdentifier.ToString());

			b.Property(x => x.Aciklama)
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxAciklamaLength);

			b.Property(x => x.Durum)
				.HasColumnType(SqlDbType.Bit.ToString());

			//indexs
			b.HasIndex(x => x.Kod);

			//relations
			b.HasOne(x => x.OzelKod1)
				.WithMany(x => x.OzelKod1Cariler)
				.OnDelete(DeleteBehavior.NoAction);

			b.HasOne(x => x.OzelKod2)
				.WithMany(x => x.OzelKod2Cariler)
				.OnDelete(DeleteBehavior.NoAction);
		});
	}
	public static void ConfigureDepo(this ModelBuilder builder)
	{
		builder.Entity<Depo>(b =>
		{
			b.ToTable(OnMuhasebeConsts.DbTablePrefix + "Depolar", OnMuhasebeConsts.DbSchema);
			b.ConfigureByConvention();

			//properties
			b.Property(x => x.Kod)
				.IsRequired()
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxKodLength);

			b.Property(x => x.Ad)
				.IsRequired()
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxAdLength);

			b.Property(x => x.OzelKod1)
				.HasColumnType(SqlDbType.UniqueIdentifier.ToString());

			b.Property(x => x.OzelKod2)
				.HasColumnType(SqlDbType.UniqueIdentifier.ToString());

			b.Property(x => x.Sube)
				.IsRequired()
				.HasColumnType(SqlDbType.UniqueIdentifier.ToString());

			b.Property(x => x.Aciklama)
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxAciklamaLength);

			b.Property(x => x.Durum)
				.HasColumnType(SqlDbType.Bit.ToString());
			//indexs
			b.HasIndex(x => x.Kod);
			//relations
			b.HasOne(x => x.OzelKod1)
				.WithMany(x => x.OzelKod1Depolar)
				.OnDelete(DeleteBehavior.NoAction);

			b.HasOne(x => x.OzelKod2)
				.WithMany(x => x.OzelKod2Depolar)
				.OnDelete(DeleteBehavior.NoAction);

			b.HasOne(x => x.Sube)
				.WithMany(x => x.Depolar)
				.OnDelete(DeleteBehavior.NoAction);
		});
	}
	public static void ConfigureDonem(this ModelBuilder builder)
	{
		builder.Entity<Donem>(b =>
		{
			b.ToTable(OnMuhasebeConsts.DbTablePrefix + "Donemler", OnMuhasebeConsts.DbSchema);
			b.ConfigureByConvention();

			//properties
			b.Property(x => x.Kod)
				.IsRequired()
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxKodLength);

			b.Property(x => x.Ad)
				.IsRequired()
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxAdLength);

			b.Property(x => x.Aciklama)
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxAciklamaLength);

			b.Property(x => x.Durum)
				.HasColumnType(SqlDbType.Bit.ToString());
			//indexs
			b.HasIndex(x => x.Kod);

			//relations

		});
	}
	public static void ConfigureFatura(this ModelBuilder builder)
	{
		builder.Entity<Fatura>(b =>
		{
			b.ToTable(OnMuhasebeConsts.DbTablePrefix + "Faturalar", OnMuhasebeConsts.DbSchema);
			b.ConfigureByConvention();

			//properties
			b.Property(x => x.FaturaTuru)
				.IsRequired()
				.HasColumnType(SqlDbType.TinyInt.ToString());
		
			b.Property(x => x.FaturaNo)
				.IsRequired()
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(FaturaConsts.MaxFaturaNoLength);

			b.Property (x => x.Tarih)
				.IsRequired()
				.HasColumnType (SqlDbType.Date.ToString());

			b.Property (x => x.BrutTutar) 
				.IsRequired()	
				.HasColumnType(SqlDbType.Money.ToString());

			b.Property(x => x.IndirimTutar) 
				.IsRequired() 
				.HasColumnType(SqlDbType.Money.ToString());

			b.Property(x => x.KdvHaricTutar)
				.IsRequired()
				.HasColumnType(SqlDbType.Money.ToString());

			b.Property(x => x.KdvTutar)
				.IsRequired()
				.HasColumnType(SqlDbType.Money.ToString());

			b.Property(x => x.NetTutar)
				.IsRequired()
				.HasColumnType(SqlDbType.Money.ToString());

			b.Property(x => x.HareketSayisi) 
				.IsRequired()
				.HasColumnType(SqlDbType.Int.ToString());

			b.Property(x => x.CariId) 
				.IsRequired() 
				.HasColumnType(SqlDbType.UniqueIdentifier.ToString());

			b.Property(x => x.OzelKod1Id)
				.HasColumnType(SqlDbType.UniqueIdentifier.ToString());

			b.Property(x => x.OzelKod2Id)
				.HasColumnType(SqlDbType.UniqueIdentifier.ToString());

			b.Property(x => x.SubeId)
				.IsRequired()
				.HasColumnType(SqlDbType.UniqueIdentifier.ToString());

			b.Property(x => x.DonemId)
				.IsRequired()
				.HasColumnType(SqlDbType.UniqueIdentifier.ToString());

			b.Property(x => x.Aciklama)
				.HasColumnType(SqlDbType.VarChar.ToString())
				.HasMaxLength(EntityConsts.MaxAciklamaLength);

			b.Property(x => x.Durum)
				.HasColumnType(SqlDbType.Bit.ToString());

			//indexs
			b.HasIndex(x => x.FaturaNo);

			//relations
			b.HasOne(x => x.Cari)
				.WithMany(x => x.Faturalar)
				.OnDelete(DeleteBehavior.NoAction);

			b.HasOne(x => x.OzelKod1)
				.WithMany(x => x.OzelKod1Faturalar)
				.OnDelete(DeleteBehavior.NoAction);

			b.HasOne(x => x.OzelKod2)
				.WithMany(x => x.OzelKod2Faturalar)
				.OnDelete(DeleteBehavior.NoAction);

			b.HasOne(x => x.Sube)
				.WithMany()
				.OnDelete(DeleteBehavior.NoAction);

			b.HasOne(x => x.Donem)
				.WithMany()
				.OnDelete(DeleteBehavior.NoAction);
		});
	}

}
