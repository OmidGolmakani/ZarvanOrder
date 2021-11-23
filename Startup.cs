using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using ZarvanOrder.Extensions.DependencyRegistration;
using ZarvanOrder.Filters;

namespace ZarvanOrder
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }
        readonly string zarvanOrigins = "ZarvanOrder";

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            this.Env = env;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            Helpers.JWTTokenManager.configuration = Configuration;
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));
            services.AddCors(options =>
            {
                options.AddPolicy(zarvanOrigins, builder => builder
                    //.SetIsOriginAllowed((host) => true)
                    //.AllowAnyMethod()
                    //.AllowAnyHeader()
                    //.AllowCredentials()
                    .WithOrigins("https://localhost:5001")
                    );
            });
            services.AddSwagger(Env);
            services.MyIdentity();
            services.AddAutoMapperConfig();
            services.AddRepositores();
            services.AddServises(Configuration);
            services.AddControllersWithViews().AddFluentValidation();
            services.AddControllers();
            if (Env.IsDevelopment() == false)
            {
                services.AddMvc(config =>
                {
                    config.Filters.Add(new CustomExceptionFilter());
                    config.Filters.Add(new CustomAuthorizationFilter());
                }).AddFluentValidation();
            }
            else
            {
                services.AddMvc().AddFluentValidation();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {

                //app.ConfigureExceptionHandler(logger);
            }
            else
            {
                //app.ConfigureExceptionHandler(logger);
            }
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZarvanOrder v1"));
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(zarvanOrigins);
            //app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
