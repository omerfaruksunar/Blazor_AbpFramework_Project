using System;
using Volo.Abp.Application.Services;

namespace AbcYazilim.OnMuhasebe.Services;
public interface ICrudAppService<TGetOutputDto, TGetListOutputDto,in TGetListInput, 
	in TCreateInput, in TUpdateInput>
	//TGetOutputDto: GetAsync kullanildiginda.
	//TGetListOutputDto: GetListAsync kullanildiginda.
	: IReadOnlyAppService<TGetOutputDto, TGetListOutputDto, Guid, TGetListInput>,
	//TCreateInput olarak db'ye gonderdigimiz Dto'yu alip db'ye gonderecek.
	//TGetOutputDto Kayit islemi yaptiktan sonra yeni haliyle geri getirecek.
	ICreateAppService<TGetOutputDto,TCreateInput>,
	IUpdateAppService<TGetOutputDto,Guid,TUpdateInput>
{
}

public interface ICrudAppService<TGetOutputDto, TGetListOutputDto, in TGetListInput,
	in TCreateInput, in TUpdateInput, in TGetCodeInput>
	:ICrudAppService<TGetOutputDto, TGetListOutputDto, TGetListInput,TCreateInput,
		TUpdateInput>,
	//Key (TKey) istedigi icin Guid gonderiyoruz
	IDeleteAppService<Guid>,
	ICodeAppService<TGetCodeInput>
{
}
