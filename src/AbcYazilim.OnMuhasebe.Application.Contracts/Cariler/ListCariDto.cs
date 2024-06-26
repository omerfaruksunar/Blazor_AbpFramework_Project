﻿using AbcYazilim.OnMuhasebe.Faturalar;
using AbcYazilim.OnMuhasebe.Makbuzlar;
using System;
using System.Collections;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace AbcYazilim.OnMuhasebe.Cariler;
public class ListCariDto : EntityDto<Guid>
{
	public string Kod { get; set; }
	public string Ad { get; set; }
	public string VergiDairesi { get; set; }
	public string VergiNo { get; set; }
	public string Telefon { get; set; }
	public string Adres { get; set; }
	public string OzelKod1Adi { get; set; }
	public string OzelKod2Adi { get; set; }
	public decimal Borc { get; set; }
	public decimal Alacak { get; set; }
	public decimal BorcBakiye => Borc - Alacak > 0 ? Borc - Alacak : 0;
	public decimal AlacakBakiye => Alacak - Borc > 0 ? Alacak - Borc : 0;
	public string Aciklama { get; set; }
	public bool Durum { get; set; }
	public ICollection<SelectFaturaDto> Faturalar { get; set; }
	public ICollection<SelectMakbuzDto> Makbuzlar { get; set; }
}
