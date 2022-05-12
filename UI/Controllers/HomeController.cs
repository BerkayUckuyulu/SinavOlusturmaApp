using AutoMapper;
using Business.Interfaces;
using Dtos.Exam;
using Dtos.Identity;
using Entities;
using Entities.Identity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using UI.Cache;
using UI.Models;

namespace UI.Controllers
{

    public class HomeController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IUserService _userService;
        private readonly IExamService _examService;
        private readonly ITitleService _titleService;
        private readonly IMemoryCache _memoryCache;
        private readonly ITitleAndContentsCache _titleCache;
        private readonly IMapper _mapper;
        private readonly IValidator<UserSignInDto> _signInDtoValidator;
        private readonly IValidator<UserCreateDto> _createDtoValidator;


        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IUserService userService, IExamService examService, ITitleService titleService, IMemoryCache memoryCache, ITitleAndContentsCache titleCache, IMapper mapper, IValidator<UserSignInDto> signInDtoValidator, IValidator<UserCreateDto> createDtoValidator)
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userService = userService;
            _examService = examService;
            _titleService = titleService;
            _memoryCache = memoryCache;
            _titleCache = titleCache;
            _mapper = mapper;
            _signInDtoValidator = signInDtoValidator;
            _createDtoValidator = createDtoValidator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View(new UserSignInDto());
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInDto userSignInDto)
        {


            if (ModelState.IsValid)
            {
                var appUser = await _userManager.FindByNameAsync(userSignInDto.UserName);
                var signInResult = _userService.SignIn(userSignInDto);
                if (signInResult.IsCompleted)
                {
                    return RedirectToAction("Index");
                }
                if (signInResult.Result.IsLockedOut)
                {

                    var lockoutEnd = await _userManager.GetLockoutEndDateAsync(appUser);

                    ModelState.AddModelError("", $"Hesabınız geçiçi süre ({(lockoutEnd.Value.UtcDateTime - DateTime.UtcNow).Minutes} dakika) kilitlenmiştir.");
                }
                else
                {
                    string message = string.Empty;


                    if (appUser != null)
                    {
                        var failedCount = await _userManager.GetAccessFailedCountAsync(appUser);
                        message = $"{(_userManager.Options.Lockout.MaxFailedAccessAttempts) - (failedCount)} kez daha yanlış girerseniz hesabınız kilitlenecektir.";
                    }
                    else
                    {
                        message = "Kullanıcı adı veya şifre hatalı";
                    }

                    ModelState.AddModelError("", message);
                }
            }

            

            return RedirectToAction("Index");


        }



        public IActionResult Create()
        {
            return View(new UserCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto userCreateDto)
        {
            var result = _createDtoValidator.Validate(userCreateDto);

            if (result.IsValid)
            {
                AppUser appUser = new() { Email = userCreateDto.Email, UserName = userCreateDto.UserName };
                var identityResult = await _userManager.CreateAsync(appUser, userCreateDto.Password);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return View(userCreateDto);
            }


        }
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }





    }
}