using LeighBriodyQuoteAPIV1.Model;
using LeighBriodyQuoteAPIV1.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace LeighBriodyQuoteAPIV1
{
    public class Startup
    {

       // private IWebHostEnvironment envri;

        public Startup(IConfiguration configuration , IWebHostEnvironment env)
        {
            Configuration = configuration;
           

        }

    
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //Now we add scope of our instances of repositorys
            //means only one instance of the repository class will be created for a given http request
            services.AddScoped<IQuoteTypeRepository, QuoteTypeRepository>();
            services.AddScoped<IQuoteRepository, QuoteRepository>();

            services.AddCors(options => options.AddDefaultPolicy(
             builder => builder.AllowAnyOrigin()  
             ));

            


            //We need to add the quote context 
            //Connection string to our SQLite database also required

            //We need to add the quote context 
            //Connection string to our SQLite database also required
            // string path = Path.Combine("Data ource=", envri.WebRootPath, "/quotes.db");
            services.AddDbContext<QuoteContext>(o => o.UseSqlite("Data source=quotes.db"));
            //services.AddDbContext<QuoteContext>(o => o.UseSqlite(path));



            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LeighBriodyQuoteAPIV1", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)


        {


            app.UseDeveloperExceptionPage();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LeighBriodyQuoteAPIV1 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //middlewear
            app.UseCors();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
