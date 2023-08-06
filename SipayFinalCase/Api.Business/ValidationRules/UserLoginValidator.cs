using Api.Schema.Request;
using FluentValidation;

namespace Api.Business.ValidationRules
{
    public class UserLoginValidator : AbstractValidator<UserLoginRequest>
    {
        public UserLoginValidator() {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanını boş bırakmayınız.")
                .MaximumLength(30).WithMessage("Kullanıcı adı en fazla 30 karakter girebilirsiniz.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail alanını boş bırakmayınız.")
                .MaximumLength(30).WithMessage("Mail alanına en fazla 30 karakter girebilirsiniz.");
        }
    }
}
