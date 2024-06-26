﻿using AbcYazilim.OnMuhasebe.Consts;
using AbcYazilim.OnMuhasebe.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace AbcYazilim.OnMuhasebe.OzelKodlar;
public class CreateOzelKodDtoValidator : AbstractValidator<CreateOzelKodDto>
{
	public CreateOzelKodDtoValidator(IStringLocalizer<OnMuhasebeResource> localizer)
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

		RuleFor(x => x.KodTuru)
			.IsInEnum()
			.WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required,
			 localizer["CodeType"]])

			.NotEmpty()
			.WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["CodeType"]]);

		RuleFor(x => x.KartTuru)
			.IsInEnum()
			.WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required,
			 localizer["CardType"]])

			.NotEmpty()
			.WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["CardType"]]);

		RuleFor(x => x.Aciklama)
			.MaximumLength(EntityConsts.MaxAciklamaLength)
			.WithMessage(localizer[OnMuhasebeDomainErrorCodes.MaxLength,
			localizer["Description"], EntityConsts.MaxAciklamaLength]);
	}
}
