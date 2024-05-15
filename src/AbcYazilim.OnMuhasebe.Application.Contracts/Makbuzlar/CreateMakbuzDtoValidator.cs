using AbcYazilim.OnMuhasebe.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace AbcYazilim.OnMuhasebe.Makbuzlar;
public class CreateMakbuzDtoValidator : AbstractValidator<CreateMakbuzDto>
{
	public CreateMakbuzDtoValidator(IStringLocalizer<OnMuhasebeResource>localizer)
	{
		
	}
}
