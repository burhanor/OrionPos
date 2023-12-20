using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
using OrionPos.Business;
using OrionPos.DataAccess.Context;
using OrionPos.Entity.Entities;
using System;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc().AddRazorRuntimeCompilation();
builder.Services.AddBusiness(builder.Configuration);

builder.Services.AddToastify(config => { config.DurationInSeconds = 2; config.Position = Position.Right; config.Gravity = Gravity.Top; });
builder.Services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });



builder.Services.AddIdentity<AppUser, IdentityRole<int>>(opt =>
{
    opt.Password = new Microsoft.AspNetCore.Identity.PasswordOptions
    {
        RequireDigit = false,
        RequiredLength = 1,
        RequiredUniqueChars = 0,
        RequireLowercase = false,
        RequireNonAlphanumeric = false,
        RequireUppercase = false
    };
    opt.Lockout.MaxFailedAccessAttempts = 5;
    opt.Lockout.AllowedForNewUsers = true;
    opt.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<DirectoryDbContext>();



builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/AccessDenied";
    options.Cookie.Name = "DirectoryMvcCookie";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(10);
    options.LoginPath = "/giris-yap";
    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    options.SlidingExpiration = true;
});


var app = builder.Build();
app.UseHttpsRedirection(); 
app.UseNotyf(); // Toast ve Notification bildirimlerinde bulunmak icin

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
