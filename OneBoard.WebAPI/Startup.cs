using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OneBoard.Core.Utilities.Security.Token;
using OneBoard.DataAccess.EF._DatabaseContext;

namespace OneBoard.WebAPI
{
    public class Startup
    {
        public IConfiguration _Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();
            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(builder =>
                {
                    //all data accepted.
                    //if some get request allowanyheader method into can be defineable.
                    //AllowAnyMethod=>Post,Put,Delete,Get accepted.
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
                //Example=>addpolicy
                //opt.AddPolicy("abcPolicy", builder =>
                //{
                //    builder.WithOrigins("https://www.abc.com").AllowAnyHeader().AllowAnyMethod();
                //});
            });
            services.Configure<TokenOptions>(_Configuration.GetSection("TokenOptions"));// Uygulamanýn tamamýnda kullanmak için created.

            var tokenOptions = _Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            //OAuth 2.0 protokolünü kullanýlýyor.Ýki kaynak arasýnda  kimlik dogrulama için kullanýlýr.Bu token bicimini kullanýyor.Bu sayede 
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer=true,
                    ValidateLifetime=true,
                    ValidateIssuerSigningKey=true,
                    ValidIssuer=tokenOptions.Issuer,
                    ValidAudience=tokenOptions.Audience,
                    IssuerSigningKey=SignHandler.GetSecurityKey(tokenOptions.SecurityKey)
                };
            });
           
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(_Configuration.GetConnectionString("DatabaseContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();
            //Example => app.UseCors("abcPolicy"); 
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapRazorPages();
            });
        }
    }
}
