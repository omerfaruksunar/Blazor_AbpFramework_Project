using AbcYazilim.OnMuhasebe.CommonDtos;
using System;
using Volo.Abp.Application.Dtos;

namespace AbcYazilim.OnMuhasebe.Faturalar;
public class FaturaNoParameterDto:IDurum,IEntityDto
{
	public FaturaTuru FaturaTuru { get; set; }
	public Guid SubeId { get; set; }
	public Guid DonemId { get; set; }
	public bool Durum { get; set; }

}
