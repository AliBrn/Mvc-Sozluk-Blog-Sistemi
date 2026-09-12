using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator: AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            // Kullanıcı Tarafında görünen kurallar Fluent Validaiton Dosyasını indirdik abstract validatior  cs dosyasına dahil ettik
            // Dbsetteki gibi kalıtım otomatik gelen kurallar  sınıf olarak category verdik 
            // Rule For  lambda başlayıp  ne yaptıklarımızı gösterdik .AbstractValidator miras aldı  ef  otomatik alıyordu ya  sınıf buda öyle
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını boş geçemezsiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori Açıklamasını boş geçemezsiniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karakterden fazla giriniz");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("20 Karakterden Fazla girmeyin");
        }
    }
}
