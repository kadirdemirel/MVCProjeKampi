using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(r => r.UserName).NotEmpty().WithMessage("Yazar adı boş geçilemez !");
            RuleFor(r => r.WriterSurname).NotEmpty().WithMessage("Yazar soyadı boş geçilemez !");
            RuleFor(r => r.WriterAbout).NotEmpty().WithMessage("Açıklama boş geçilemez !");
            RuleFor(r => r.WriterAbout).Must((r, t) => r.WriterAbout.Contains("a")).WithMessage("Yazar hakkında mutlaka a harfi olmalıdır.");
            RuleFor(r => r.UserName).MinimumLength(2).WithMessage("Yazar adı en az 2 karakter olmalıdır.");
            RuleFor(r => r.UserName).MaximumLength(50).WithMessage("Yazar adı en fazla 50 karakter olmalıdır.");
            RuleFor(r => r.WriterTitle).NotEmpty().MaximumLength(50).WithMessage("Açıklama boş geçilemez !");


        }
    }
}
