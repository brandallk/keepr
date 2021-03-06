﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using keepr.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace keepr
{
    public class Startup
    {
        // private readonly string _connectionString;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            // _connectionString = configuration.GetSection("DB").GetValue<string>("MySQLConnectionString");
            // _connectionString = "server=sql3.freemysqlhosting.net;port=3306;database=sql3232283;user id=sql3232283;password=Ke5NLMtrwm";
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => 
            {
                options.LoginPath = "/Account/Login/";
                options.Events.OnRedirectToLogin = (context) =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });

            services.AddCors(options => 
            {
                options.AddPolicy("CorsDevPolicy", builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });

            services.AddMvc();
            services.AddTransient<IDbConnection>(x => CreateDbContext());
            services.AddTransient<UserRepository>();
            services.AddTransient<KeepsRepository>();
            services.AddTransient<TagsRepository>();
            services.AddTransient<KeeptagsRepository>();
            services.AddTransient<VaultsRepository>();
        }

        private IDbConnection CreateDbContext()
        {
            // var connection = new MySqlConnection(_connectionString);
            var connection = new MySqlConnection("server=sql3.freemysqlhosting.net;port=3306;database=sql3232283;user id=sql3232283;password=Ke5NLMtrwm");
            connection.Open();
            return connection;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("CorsDevPolicy");
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
