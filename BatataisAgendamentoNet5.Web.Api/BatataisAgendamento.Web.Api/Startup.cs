using AutoMapper;
using BatataisAgendamento.Web.Api.Mapper;
using BatataisAgendamento.Web.Bll;
using BatataisAgendamento.Web.Bll.Interface;
using BatataisAgendamento.Web.Dal;
using BatataisAgendamento.Web.Dal.Interface;
using BatataisAgendamento.Web.Info.SqlDbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql;
using BatataisAgendamento.Web.Info.Data.Configuration;
using BatataisAgendamento.Web.Info.Data.Configuration.Interface;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

namespace BatataisAgendamento.Web.Api
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
            services.AddControllers();
            services.AddScoped<ISchedulingDayBll, SchedulingDayBll>();
            services.AddScoped<ISchedulingDayDal, SchedulingDayDal>();
            services.AddScoped<ISchedulingHourBll, SchedulingHourBll>();
            services.AddScoped<ISchedulingHourDal, SchedulingHourDal>();

            string mySqlConnection = Configuration.GetConnectionString("DefaultConnection");

            //services.AddControllers().AddJsonOptions(x =>
            //    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            services.AddDbContextPool<SqlDbContext>(options =>
            options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BatataisAgendamento.Web.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BatataisAgendamento.Web.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
