﻿using System;
using Volo.Abp.Application.Dtos;

namespace AbcYazilim.OnMuhasebe.Parametreler;
public class SelectFirmaParametreDto : EntityDto<Guid>
{
	public Guid SubeId { get; set; }
	public string SubeAdi { get; set; }
	public Guid DonemId { get; set; }
	public int DonemAdi { get; set; }
	public Guid? DepoId { get; set; }
	public string DepoAdi { get; set; }
}
