using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
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
            var connectionString = builder.Configuration.GetConnectionString("RestauranteConnection");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("A conexão com o banco de dados não foi configurada corretamente.");
            }

            builder.Services.AddDbContext<RestauranteContext>(
                options => options.UseMySQL(connectionString));

            builder.Services.AddTransient<IGrupoCardapioService, GrupoCardapioService>();

            builder.Services.AddScoped<IItemCardapioService, ItemCardapioService>();

            builder.Services.AddScoped<IFormaPagamentoService, FormaPagamentoService>();

            builder.Services.AddScoped<ITipoFuncionario, TipoFuncionarioService>();

            builder.Services.AddScoped<ITipoRestauranteService, TipoRestauranteService>();

            builder.Services.AddScoped<IRestauranteService, RestauranteService>();

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

            app.Run();
        }
    }
}
