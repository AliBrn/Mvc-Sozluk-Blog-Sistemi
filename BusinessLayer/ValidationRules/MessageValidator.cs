using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Konuyu boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsin");
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("E-posta adresi boş olamaz.").EmailAddress().WithMessage("Geçersiz e-posta adresi.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakter girin");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("100 karakterden fazla girmeyin");
        }
    }
}
