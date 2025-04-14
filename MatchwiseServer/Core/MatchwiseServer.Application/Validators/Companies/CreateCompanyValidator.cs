using FluentValidation;
using MatchwiseServer.Application.ViewModels.Companies;

namespace MatchwiseServer.Application.Validators.Companies
{
    public class CreateCompanyValidator : AbstractValidator<VM_Create_Company>
    {
        public CreateCompanyValidator()
        {
            RuleFor(c => c.CorporateName)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Şirket adı boş bırakılamaz!")
                .MaximumLength(50)
                    .WithMessage("Şirket ismi en fazla 50 karakter olabilir!")
                .MinimumLength(10)
                    .WithMessage("Şirket adı en az 10 karakter olmalıdır!");

            RuleFor(c => c.TaxNumber)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Vergi numarası boş bırakılamaz")
                .Length(11)
                    .WithMessage("Vergi numarası 11 hane olmaldır!")
                .Must(taxNum => !taxNum.StartsWith("0"))
                    .WithMessage("Vergi numarası 0 ile başlayamaz!")
                .Matches("^[0-9]+$")
                    .WithMessage("Vergi numarası yalnızca rakamlardan oluşmalıdır!");

            RuleFor(c => c.Sector)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Sektör bilgisi boş bırakılamaz!")
                .MaximumLength(20)
                    .WithMessage("Sektör bilgisi en fazla 20 karakter olabilir!")
                .MinimumLength(5)
                    .WithMessage("Sektör bilgisi en az 5 karakter olmalıdır!");

            RuleFor(c => c.Location)
                .MaximumLength(20)
                    .WithMessage("Konum bilgisi en fazla 20 karakter olabilir!")
                .MinimumLength(3)
                    .WithMessage("Konum bilgisi en az 3 karakter olmalıdır!");

            RuleFor(c => c.Email)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Email alanı boş bırakılamaz!")
                .EmailAddress()
                    .WithMessage("Geçerli bir email adresi giriniz!");

            RuleFor(c => c.Password)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Şifre alanı boş bırakılamaz!")
                .MinimumLength(5)
                    .WithMessage("Şifre en az 5 karakter olmalıdır!")
                .Matches(@"[A-Za-z]")
                    .WithMessage("Şifre en az bir harf içermelidir!")
                .Matches(@"\d")
                    .WithMessage("Şifre en az bir rakam içermelidir!");
        }
    }
}
