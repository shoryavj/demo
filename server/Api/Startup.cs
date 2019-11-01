using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // if (System.Environment.GetEnvironmentVariables("ASPNETCORE_ENVIRONMENT") == "Development")


            var securityKey = Configuration["securityKey"];
           // string securityKey = "This_is_securityKey";
            //var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //           //what to validate
            //           ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateIssuerSigningKey = true,
            //           //Setup Validate Data
            //           ValidIssuer = "admin",
            //            ValidAudience = "reader",
            //            IssuerSigningKey = symmetricSecurityKey
            //        };
            //    });

            // services.Configure<DatabaseSettings>(
            //     Configuration.GetSection(nameof(DatabaseSettings)));

            // services.AddSingleton<IDatabaseSettings>(sp =>
            //     sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);


            services.AddSingleton<IMongoDBContext,MongoDBContext>();



            services.AddSingleton<IAssignmentService, AssignmentService>()
                    .AddSingleton<IConfiguration>(Configuration);

            services.AddSingleton<IArticleService, ArticleService>()
                    .AddSingleton<IConfiguration>(Configuration);

            services.AddSingleton<IUserService, UserService>()
                    .AddSingleton<IConfiguration>(Configuration);
                    
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "My API", Version = "v1" });
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            // app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            //app.UseSwaggerUI();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
