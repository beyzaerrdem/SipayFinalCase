using Api.Schema.Request;
using FluentValidation;

namespace Api.Business.ValidationRules
{
    public class UserValidator : AbstractValidator<UserRequest>
    {
        public UserValidator() 
        { 
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanını boş bırakmayınız.");
            RuleFor(x => x.Lastname).NotEmpty().WithMessage("Soyisim alanını boş bırakmayınız.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail alanını boş bırakmayınız.");
            RuleFor(x => x.Tc).NotEmpty().MaximumLength(11).WithMessage("Tc alanını boş bırakmayınız.");
        }
    }
}
