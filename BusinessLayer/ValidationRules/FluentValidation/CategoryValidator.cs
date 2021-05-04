using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(r => r.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez !");
            RuleFor(r => r.CategoryDescription).NotEmpty().WithMessage("Açıklama boş geçilemez !");
            RuleFor(r => r.CategoryName).MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır.");
            RuleFor(r => r.CategoryName).MaximumLength(20).WithMessage("Kategori adı en fazla 20 karakter olmalıdır.");

        }
    }
}
