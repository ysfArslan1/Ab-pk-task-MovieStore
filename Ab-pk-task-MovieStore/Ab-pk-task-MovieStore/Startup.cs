﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Ab_pk_task_MovieStore.DBOperations;
using Ab_pk_task_MovieStore.Middlewares;
using FluentValidation;
using System.Reflection;
using Ab_pk_task_MovieStore.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Ab_pk_task_MovieStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.

            // Yetkilendirme için jwt bearer eklenemsi
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Token:Issuer"],
                    ValidAudience = Configuration["Token:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
            services.AddControllers()
                .AddNewtonsoftJson(); // httppatch için eklendi
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
           
            // dbcontentext servicelere eklendi ve inmemory oluşturuldu
            services.AddDbContext<PatikaDbContext>(Options => Options.UseInMemoryDatabase(databaseName:"PatikaDb"));
            services.AddScoped<IPatikaDbContext>(provider => provider.GetService<PatikaDbContext>());
            // autoMapper Dto için eklendi
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSingleton<ILoggerService, ConsoleLogger>();
            //services.AddSingleton<ILoggerService, DBLogger>(); // depedency İnjection yapılarak bagımlılıklar azaltılır.
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // jwtBearer 
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            //middlewaare
            app.UseCustomExceptionMiddleware();

            app.UseEndpoints(x => { x.MapControllers(); });
        }
    }
}
