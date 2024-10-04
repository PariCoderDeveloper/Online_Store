using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Interfaces.Context;
using Shop.Application.Interfaces.FacadPattern;
using Shop.Application.Services.Cart;
using Shop.Application.Services.Commen.Query.GetMenuService;
using Shop.Application.Services.HomePage.HomePageFacad;
using Shop.Application.Services.Product.Command.AddNewProduct;
using Shop.Application.Services.Product.FacadPattern;
using Shop.Application.Services.Product.Queries.GetParentCategory;
using Shop.Application.Services.Product.Queries.GetProductForSite;
using Shop.Application.Services.Users.Commands.ChangeStatusUser;
using Shop.Application.Services.Users.Commands.LoginUser;
using Shop.Application.Services.Users.Commands.RegisterUser;
using Shop.Application.Services.Users.Commands.RemoveUser;
using Shop.Application.Services.Users.Commands.UpdateUser;
using Shop.Application.Services.Users.Queries.GetRole;
using Shop.Application.Services.Users.Queries.GetUsers;
using Shop.Application.Validations;
using Shop.Application.Validations.FacadeValidation;
using Shop.Domain.Entities.Users;
using Shop.Persistence.Context;
using Shop.Presentation.Utilities;
using Shop.Presentation.ViewModels.AuthenticationViewModel;

var builder = WebApplication.CreateBuilder(args);
string ConnectionString = "data source=UNKNOWN\\SQLEXPRESS01;initial catalog=StoreDB;integrated security=true;TrustServerCertificate=yes;";

// Add services to the container.

builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(option =>
{
    option.LoginPath = new PathString("/");
    option.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
});

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IGetUserService, GetUserService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();
builder.Services.AddScoped<IUpdateUserService, UpdateUserService>();
builder.Services.AddScoped<IChangeStatusUser, ChangeStatusUser>();
builder.Services.AddScoped<ILoginUser, LoginUser>();
builder.Services.AddScoped<IValidator<SignupViewModel>, SignupViewModelValidator>();
builder.Services.AddScoped<IGetMenuService, GetMenuService>();
builder.Services.AddScoped<IGetParentCategoryService, GetParentCategoryService>();

// Use Facad (Facad Inject)
builder.Services.AddScoped<IProductFacad, ProductFacad>();
builder.Services.AddScoped<IHomePageFacad, HomePageFacad>();
builder.Services.AddScoped<IValidationFacad, ValifationFacad>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<CookiesManager>();
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RequestEditDtoValidator>());

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<DataBaseContext>(option => option.UseSqlServer(ConnectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllerRoute(
     name: "areas",
     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
   );
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
