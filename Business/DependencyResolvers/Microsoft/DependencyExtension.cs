using Business.Interfaces;
using Business.Services;
using Business.Validation.FluentValidation;
using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Dtos.Identity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Microsoft
{

    //Startup'ı şişirmemek adına buraya extend metot yazdım.
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<ITitleRepository, TitleRepositoy>();
            services.AddScoped<ITitleService, TitleService>();

            services.AddTransient<IValidator<UserSignInDto>, UserSignInDtoValidator>();
            services.AddTransient<IValidator<UserCreateDto>, UserCreateDtoValidator>();
        }
    }
}
