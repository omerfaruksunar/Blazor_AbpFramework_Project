using Volo.Abp;

namespace AbcYazilim.OnMuhasebe.Exceptions;
public class CannotBeDeletedException : BusinessException
{
	public CannotBeDeletedException() : base(OnMuhasebeDomainErrorCodes.CannotBeDeleted)
	{
	}
}
