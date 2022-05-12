using Business.Interfaces;
using Dtos.Exam;
using Dtos.Identity;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UserService:IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> SignIn(UserSignInDto userSıgnInModel)
        {
            
                var user = await _userManager.FindByNameAsync(userSıgnInModel.UserName);
                var signInResult = await _signInManager.PasswordSignInAsync(userSıgnInModel.UserName, userSıgnInModel.Password, userSıgnInModel.RememberMe, true);
                
            return signInResult;
        }
        public void CreateUserExam(AppUser appUser ,ExamCreateDto examCreateDto)
        {
            
        }
   
    }
}
