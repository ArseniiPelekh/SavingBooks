using DB;
using DB.Interface;
using DB.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SavingBooks.Excel;
using SavingBooks.Excel.Interfaces;
using SavingBooks.Pdf;
using SavingBooks.Pdf.Interfaces;

namespace SavingBooks
{
    public class Startup
    {
        private IConfigurationRoot _confSting;

        public Startup(IConfiguration configuration, IWebHostEnvironment host)
        {
            Configuration = configuration;

            _confSting = new ConfigurationBuilder().SetBasePath(host.ContentRootPath)
               .AddJsonFile("dbSettings.json")
               .AddEnvironmentVariables().Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppContext>(options => options.UseSqlServer(_confSting.GetConnectionString("DefaultConnection")));

            services.AddControllers();
            
            services.AddTransient<IPdfExportService, PdfExportService>();
            services.AddTransient<IBooksRepository, BooksRepository>();
            services.AddTransient<IExcelExportService, ExcelExportService>();

            services.AddControllersWithViews();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Tweetbook API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            var swaggeroptins = new Options.SwaggerOptions();
            Configuration.GetSection(nameof(Options.SwaggerOptions)).Bind(swaggeroptins);

            app.UseSwagger(options =>
            {
                options.RouteTemplate = swaggeroptins.JsonRoute;
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(swaggeroptins.UiEndpoint, swaggeroptins.Description);
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
