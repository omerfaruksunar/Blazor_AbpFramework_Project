using AbcYazilim.OnMuhasebe.Consts;
using AbcYazilim.OnMuhasebe.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace AbcYazilim.OnMuhasebe.Subeler;
public class CreateSubeDtoValidator : AbstractValidator<CreateSubeDto>
{
	public CreateSubeDtoValidator(IStringLocalizer<OnMuhasebeResource>localizer)
	{
		RuleFor(x => x.Kod)
			.NotEmpty()
			.WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Code"]])

			.MaximumLength(EntityConsts.MaxKodLength)
			.WithMessage(localizer[OnMuhasebeDomainErrorCodes.MaxLength, localizer["Code"],
				EntityConsts.MaxKodLength]);

		RuleFor(x => x.Ad)
			.NotEmpty()
			.WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Name"]])

			.MaximumLength(EntityConsts.MaxAdLength)
			.WithMessage(localizer[OnMuhasebeDomainErrorCodes.MaxLength,
			localizer["Name"], EntityConsts.MaxAdLength]);

		RuleFor(x => x.Aciklama)
			.MaximumLength(EntityConsts.MaxAciklamaLength)
			.WithMessage(localizer[OnMuhasebeDomainErrorCodes.MaxLength,
			localizer["Description"], EntityConsts.MaxAciklamaLength]);
	}
}
