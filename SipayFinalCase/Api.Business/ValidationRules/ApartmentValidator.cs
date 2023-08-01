using Api.DataAccess.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Business.ValidationRules
{
    public class ApartmentValidator : AbstractValidator<Apartment>
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
