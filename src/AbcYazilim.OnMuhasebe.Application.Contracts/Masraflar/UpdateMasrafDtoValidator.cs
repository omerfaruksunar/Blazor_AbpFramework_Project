using AbcYazilim.OnMuhasebe.Consts;
using AbcYazilim.OnMuhasebe.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;

namespace AbcYazilim.OnMuhasebe.Masraflar;
public class UpdateMasrafDtoValidator : AbstractValidator<UpdateMasrafDto>
{
	public UpdateMasrafDtoValidator(IStringLocalizer<OnMuhasebeResource> localizer)
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

		RuleFor(x => x.KdvOrani)
			.NotNull()
			.WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["ValueAddedTaxRate"]])
			.GreaterThanOrEqualTo(0).WithMessage(localizer[OnMuhasebeDomainErrorCodes.GreaterThanOrEqual,
			 localizer["ValueAddedTaxRate"], localizer["ToZero"], localizer["ThanZero"]]);

		RuleFor(x => x.BirimFiyat)
			.NotNull()
			.WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required,
			 localizer["UnitPrice"]])
			.GreaterThanOrEqualTo(0).WithMessage(localizer[OnMuhasebeDomainErrorCodes.GreaterThanOrEqual,
			 localizer["UnitPrice"], localizer["ToZero"], localizer["ThanZero"]]);

		RuleFor(x => x.Barkod)
			.MaximumLength(EntityConsts.MaxBarkodLength)
			.WithMessage(localizer[OnMuhasebeDomainErrorCodes.MaxLength,
			localizer["BarCode"], EntityConsts.MaxBarkodLength]);

		RuleFor(x => x.BirimId)
			.Must(x => x.HasValue && x.Value != Guid.Empty)
			.WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Unit"]]);

		RuleFor(x => x.Aciklama)
			.MaximumLength(EntityConsts.MaxAciklamaLength)
			.WithMessage(localizer[OnMuhasebeDomainErrorCodes.MaxLength,
			localizer["Description"], EntityConsts.MaxAciklamaLength]);
	}
}
