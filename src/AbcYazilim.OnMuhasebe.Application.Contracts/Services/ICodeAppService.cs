using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbcYazilim.OnMuhasebe.Services;

//IApplicationService: Abp sunuyor, Tüm app servicelerin buradan kalitim almasi gerekiyor.
public interface ICodeAppService<in TGetCodeInput>:IApplicationService
{
	Task<string> GetCodeAsync(TGetCodeInput getCodeInput);
}
