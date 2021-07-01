using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SkillValidator : AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            RuleFor(x => x.SkillName).NotEmpty().WithMessage("Yetenek Adını Boş Geçemezsiniz");
            RuleFor(x => x.SkillName).MinimumLength(5).WithMessage("Lütfen En Az 5 Karakter Girişi Yapın");
            RuleFor(x => x.SkillName).MaximumLength(20).WithMessage("Lütfen 20 Karakterden Fazla Bilgi Girişi Yapmayın");
            RuleFor(x => x.SkillScore).NotEmpty().WithMessage("Yetenek Düzeyi Bilgisini Boş Geçemezsiniz");
            RuleFor(x => x.SkillScore).InclusiveBetween(1, 100).WithMessage("Lütfen 1 İle 100 Arasında Bir Değer Girin");
        }
    }
}
