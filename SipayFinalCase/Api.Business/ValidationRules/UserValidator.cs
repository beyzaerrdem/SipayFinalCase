using Api.Schema.Request;
using FluentValidation;

namespace Api.Business.ValidationRules
{
    public class UserValidator : AbstractValidator<UserRequest>
    {
        public UserValidator() 
        { 
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanını boş bırakmayınız.")
                .MaximumLength(30).WithMessage("İsim alanına en fazla 30 karakter girebilirsiniz.");
            RuleFor(x => x.Lastname).NotEmpty().WithMessage("Soyisim alanını boş bırakmayınız.")
                .MaximumLength(30).WithMessage("Soyisim alanına en fazla 30 karakter girebilirsiniz.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail alanını boş bırakmayınız.")
                .MaximumLength(30).WithMessage("Mail alanına en fazla 30 karakter girebilirsiniz."); 
            RuleFor(x => x.Tc).NotEmpty().WithMessage("Tc alanını boş bırakmayınız.")
                .Length(11).WithMessage("Tc alanı 11 karakter olmalıdır.")
                .Matches(@"^\d+$").WithMessage("Tc sadece rakamlardan oluşmalıdır.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon numarası alanını boş bırakmayınız.")
                .Matches(@"^\d+$").WithMessage("Telefon numarası sadece rakamlardan oluşmalıdır.");
        }
    }
}
