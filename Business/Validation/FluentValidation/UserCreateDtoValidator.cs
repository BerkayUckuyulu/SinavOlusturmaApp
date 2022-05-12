using Dtos.Identity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class UserCreateDtoValidator:AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş bırakılamaz. (Kayıt işlemi doğrulamasında FluentValidation'ı da  kullandım. )");
            RuleFor(x=>x.Password).NotEmpty().WithMessage("Parola alanı boş bırakılamaz.");
            RuleFor(x=>x.ConfirmPassword).NotEmpty().WithMessage("Parola tekrarı  boş bırakılamaz.");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Parolalar eşleşmiyor.");
            RuleFor(x=>x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş bırakılamaz.");
        }
    }
}
