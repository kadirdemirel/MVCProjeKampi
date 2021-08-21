using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
  public  class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(r => r.UserMail).NotEmpty().WithMessage("Mail adresini boş geçemezsiniz.");
            RuleFor(r => r.Subject).NotEmpty().WithMessage("Konu adı boş geçilemez !");
            RuleFor(r => r.Message).NotEmpty().WithMessage("Mesaj boş geçilemez !");
            RuleFor(r => r.UserName).MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır.");
            RuleFor(r => r.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez !");

        }
    }
}
