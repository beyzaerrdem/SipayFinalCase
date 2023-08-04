using Api.Schema.Request;
using FluentValidation;

namespace Api.Business.ValidationRules
{
    public class InvoiceValidator : AbstractValidator<InvoiceRequest>
    {
        public InvoiceValidator() 
        {
            RuleFor(x => x.InvoiceAmount).NotNull().WithMessage("Fatura tutarını boş bırakmayınız.");
        }
    }
}
