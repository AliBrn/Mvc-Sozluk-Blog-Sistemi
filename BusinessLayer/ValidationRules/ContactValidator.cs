using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator() {

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adını Boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçemezsiniz");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj kısmını boş geçemezsiniz");

            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("En az 5 karakterden fazla olmalı");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("50 karakterden az olmalı");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen ismi boş geçmeyin");
            RuleFor(x => x.Message).MinimumLength(5).WithMessage("Mesaj kısmını boş bırakamazsınız");

        }
    }
}
