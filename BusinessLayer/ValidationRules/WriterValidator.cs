using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını boş geçemezsiniz");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage(" Yazar Adını Lütfen en az 3 karakterden fazla giriniz");
            RuleFor(x => x.WriterName).MaximumLength(15).WithMessage(" Yazar Adını 20 Karakterden Fazla girmeyin");

            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Soyadını boş geçemezsiniz");
            RuleFor(x => x.WriterSurName).MinimumLength(3).WithMessage(" Yazar Adını Soyadını en az 3 karakterden fazla giriniz");
            RuleFor(x => x.WriterSurName).MaximumLength(10).WithMessage("Soyadını 10 Karakterden Fazla girmeyin");

            // Must mutlaka anlamında şart olarak kullanır.
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar  Hakkında kısmını boş geçemezsiniz");
            RuleFor(x => x.WriterAbout).MaximumLength(100).WithMessage("Hakkında Kısmına 100 Karakterden Fazla girmeyin");
            RuleFor(x => x.WriterAbout).Must(x => x.Contains("a")).WithMessage("Hakkında kısmında 'a' harfi bulunmalıdır."); 
            

        }
    }
}
