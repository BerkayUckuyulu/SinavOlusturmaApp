using Dtos.Identity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class UserSignInDtoValidator:AbstractValidator<UserSignInDto>
    {
        public UserSignInDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz.");
        }
    }
}
