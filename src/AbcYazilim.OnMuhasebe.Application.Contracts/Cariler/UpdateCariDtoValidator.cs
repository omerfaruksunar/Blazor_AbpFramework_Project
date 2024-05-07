using AbcYazilim.OnMuhasebe.Consts;
using AbcYazilim.OnMuhasebe.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace AbcYazilim.OnMuhasebe.Cariler;
public class UpdateCariDtoValidator : AbstractValidator<UpdateCariDto>
{
	public UpdateCariDtoValidator(IStringLocalizer<OnMuhasebeResource> localizer)
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

		RuleFor(x => x.VergiDairesi)
			.MaximumLength(CariConsts.MaxVergiDairesiLength)
			.WithMessage(localizer[OnMuhasebeDomainErrorCodes.MaxLength,
			localizer["TaxAdministration"], CariConsts.MaxVergiDairesiLength]);

		RuleFor(x => x.VergiNo)
			.MaximumLength(CariConsts.MaxVergiNoLength)
			.WithMessage(localizer[OnMuhasebeDomainErrorCodes.MaxLength,
			localizer["TaxNumber"], CariConsts.MaxVergiNoLength]);

		RuleFor(x => x.Telefon)
			.MaximumLength(EntityConsts.MaxTelefonLength)
			.WithMessage(localizer[OnMuhasebeDomainErrorCodes.MaxLength,
			localizer["Telephone"], EntityConsts.MaxTelefonLength]);

		RuleFor(x => x.Adres)
			.MaximumLength(EntityConsts.MaxAdresLength)
			.WithMessage(localizer[OnMuhasebeDomainErrorCodes.MaxLength,
			localizer["Address"], EntityConsts.MaxAdresLength]);

		RuleFor(x => x.Aciklama)
			.MaximumLength(EntityConsts.MaxAciklamaLength)
			.WithMessage(localizer[OnMuhasebeDomainErrorCodes.MaxLength,
			localizer["Description"], EntityConsts.MaxAciklamaLength]);
	}
}
