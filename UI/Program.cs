
using AutoMapper;
using Business.DependencyResolvers.Microsoft;
using Business.MappingForDtos.AutoMapper;
using DataAccess;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UI.Cache;
using UI.CustomErrorDescriber;
using UI.MappingForModels.AutoMapper;

var builder = WebApplication.CreateBuilder(args);



//UI dýþýndaki baðýmlýlýklarý business tarafýnda ServiceCollection'a extend metot ile ekledim.
builder.Services.AddDependencies();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IDbContext>();
builder.Services.AddScoped<ITitleAndContentsCache, TitleAndContentsCache>();

var mapperConfiguration = new MapperConfiguration(opt =>
{
    opt.AddProfile(new ExamModelProfile());
    opt.AddProfile(new ExamDtoProfile());
    
});
var mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddMemoryCache();

builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.Password.RequireDigit = false;
    opt.Password.RequiredLength = 1;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Lockout.MaxFailedAccessAttempts = 3;

}).AddErrorDescriber<CustomErrorDescriber>().AddEntityFrameworkStores<IDbContext>().AddDefaultTokenProviders();

var app = builder.Build();




//builder.Services.AddDependencies(builder.Configuration);

//Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
