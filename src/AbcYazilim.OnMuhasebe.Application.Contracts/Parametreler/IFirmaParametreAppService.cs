using AbcYazilim.OnMuhasebe.Services;
using System;
using System.Threading.Tasks;

namespace AbcYazilim.OnMuhasebe.Parametreler;
public interface IFirmaParametreAppService:ICrudAppService<SelectFirmaParametreDto,
	SelectFirmaParametreDto,FirmaParametreListParameterDto,CreateFirmaParametreDto,
	UpdateFirmaParametreDto>
{
	//Firma Parametreye özel extra functionları buraya ekleyebiliriz.
	Task<bool> UserAnyAsync(Guid userId);
}
