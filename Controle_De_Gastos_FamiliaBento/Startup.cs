using Domain;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Expenses;
using Services.Revenues;

namespace Controle_De_Gastos_FamiliaBento
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IRevenueRepository, RevenueRepository>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IRevenueService, RevenueService>();

            services.AddControllers();
            services.AddSwaggerGen();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();



            //Configuration DBContext
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                string connectionString = Configuration.GetConnectionString("LocalConnection");
                options.UseMySql(connectionString,
                    ServerVersion.AutoDetect(connectionString),
                    mySqlOptions =>
                        mySqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 10,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null));
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseHttpsRedirection();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseStaticFiles();

            app.UseAuthentication();
            //app.UseIdentityServer();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
