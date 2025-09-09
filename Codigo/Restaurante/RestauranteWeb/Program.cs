using Core;
using Core.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestauranteWeb.Areas.Identity.Data;
using RestauranteWeb.Data;
using Service;

namespace RestauranteWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Ensure the connection string is not null or empty to avoid CS8604
            var restauranteConnectionString = builder.Configuration.GetConnectionString("RestauranteConnection");
            if (string.IsNullOrEmpty(restauranteConnectionString))
            {
                throw new InvalidOperationException("A conexão com o banco de dados n�o foi configurada corretamente.");
            }

            var identityConnectionString = builder.Configuration.GetConnectionString("RestauranteConnection");
            if (string.IsNullOrEmpty(identityConnectionString))
            {
                throw new InvalidOperationException("A conexão com o banco de dados n�o foi configurada corretamente.");
            }

            builder.Services.AddDbContext<RestauranteContext>(
                options => options.UseMySQL(restauranteConnectionString));

            builder.Services.AddDbContext<IdentityContext>(
                options => options.UseMySQL(identityConnectionString));

            builder.Services.AddDefaultIdentity<RestauranteWebUser>(options =>
            {
                // SignIn settings
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;

                // Default User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 -._ @+";
                options.User.RequireUniqueEmail = false;

                // Default Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            }).AddEntityFrameworkStores<IdentityContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.Cookie.Name = "RestauranteWebCookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Identity/Account/Login";
                // ReturnUrlParameter requires
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            builder.Services.AddTransient<IGrupoCardapioService, GrupoCardapioService>();

            builder.Services.AddScoped<IItemCardapioService, ItemCardapioService>();

            builder.Services.AddScoped<IFormaPagamentoService, FormaPagamentoService>();

            builder.Services.AddScoped<ITipoFuncionario, TipoFuncionarioService>();

            builder.Services.AddScoped<ITipoRestauranteService, TipoRestauranteService>();

            builder.Services.AddScoped<IRestauranteService, RestauranteService>();

            builder.Services.AddScoped<IMesaService, MesaService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}
