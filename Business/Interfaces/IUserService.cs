using Dtos.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<SignInResult> SignIn(UserSignInDto userSıgnInModel);
    }
}
