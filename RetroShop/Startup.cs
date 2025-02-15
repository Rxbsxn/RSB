﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RetroShop.Services;
using RetroShop.Utils;

namespace RetroShop
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
      services.Configure<DatabaseSettings>(Configuration.GetSection(nameof(DatabaseSettings)));
      services
        .AddSingleton<IDatabaseSettings>(singleton =>
          singleton.GetRequiredService<IOptions<DatabaseSettings>>().Value
        )
        .AddSingleton<UserService>()
        .AddSingleton<AuctionService>();
      
      services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
      {
        builder.WithOrigins("http://localhost:5001").AllowAnyMethod().AllowAnyHeader();
      }));
      
      services
        .AddMvc()
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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

      app.UseCors(builder => 
        builder
          .AllowAnyMethod()
          .AllowAnyOrigin()
          .AllowAnyHeader());
      app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}