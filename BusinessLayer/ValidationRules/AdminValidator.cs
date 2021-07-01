using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.AdminName).NotEmpty().WithMessage("Kullanıcının Adını Boş Geçemezsiniz");
            RuleFor(x => x.AdminSurname).NotEmpty().WithMessage("Kullanıcının Soyadını Boş Geçemezsiniz");
            RuleFor(x => x.AdminName).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapın");
            RuleFor(x => x.AdminSurname).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapın");
            RuleFor(x => x.AdminName).MaximumLength(50).WithMessage("Lütfen 50 Karakterden Fazla Bilgi Girişi Yapmayın");
            RuleFor(x => x.AdminSurname).MaximumLength(50).WithMessage("Lütfen 50 Karakterden Fazla Bilgi Girişi Yapmayın");
            RuleFor(x => x.AdminUserName).NotEmpty().WithMessage("Admin Kullanıcı Adını Boş Geçemezsiniz");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Admin Parolasını Boş Geçemezsiniz");
            RuleFor(x => x.AdminPassword).MinimumLength(8).WithMessage("Lütfen En Az 8 Karakter Uzunluğunda Bir Parola Giriniz");
            RuleFor(x => x.AdminRole).NotEmpty().WithMessage("Lütfen Mutlaka Bir Admin Rolü Seçiniz");
            RuleFor(x => x.AdminStatus).NotEmpty().WithMessage("Kullanıcı Durumunu Boş Geçemezsiniz");
        }
    }
}
