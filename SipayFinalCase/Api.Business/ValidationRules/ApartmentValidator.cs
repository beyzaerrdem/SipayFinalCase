using Api.DataAccess.Models;
using Api.Schema.Request;
using Api.Schema.Response;
using FluentValidation;

namespace Api.Business.ValidationRules
{
    public class ApartmentValidator : AbstractValidator<ApartmentRequest>
    {
        public ApartmentValidator()
        { 
            RuleFor(x => x.ApartmentNo).NotEmpty().WithMessage("Lütfen apartman numarası giriniz.");
            RuleFor(x => x.Block).NotEmpty().WithMessage("Lütfen Blok giriniz.");
            RuleFor(x => x.Floor).NotEmpty().WithMessage("Lütfen kat bilgisi giriniz.");
            RuleFor(x => x.Type).NotEmpty().WithMessage("Lütfen daire tipi giriniz.");
        }
    }
}
