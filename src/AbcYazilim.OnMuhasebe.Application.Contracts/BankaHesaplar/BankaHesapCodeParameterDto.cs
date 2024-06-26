﻿using AbcYazilim.OnMuhasebe.CommonDtos;
using System;
using Volo.Abp.Application.Dtos;

namespace AbcYazilim.OnMuhasebe.BankaHesaplar;
public class BankaHesapCodeParameterDto : IEntityDto, IDurum
{
	public Guid SubeId { get; set; }
	public bool Durum { get; set; }
}
