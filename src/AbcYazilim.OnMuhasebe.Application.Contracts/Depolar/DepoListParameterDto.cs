﻿using AbcYazilim.OnMuhasebe.CommonDtos;
using System;
using Volo.Abp.Application.Dtos;

namespace AbcYazilim.OnMuhasebe.Depolar;
public class DepoListParameterDto : PagedResultRequestDto ,IDurum , IEntityDto
{
	public Guid SubeId { get; set; }
	public bool Durum { get; set; }
}
