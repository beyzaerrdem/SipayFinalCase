using Api.DataAccess.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Business.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() 
        { 
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanını boş bırakmayınız.");
            RuleFor(x => x.Lastname).NotEmpty().WithMessage("Soyisim alanını boş bırakmayınız.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail alanını boş bırakmayınız.");
            RuleFor(x => x.Tc).NotEmpty().WithMessage("Tc alanını boş bırakmayınız.");
        }
    }
}
