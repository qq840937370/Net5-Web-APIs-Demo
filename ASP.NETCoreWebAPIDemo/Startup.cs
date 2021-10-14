using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETCoreWebAPIDemo
{
    /// <summary>
    /// Startup启动配置
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // 此方法由运行时调用。使用此方法向容器中添加服务。
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP.NETCoreWebAPI案例", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // 此方法由运行时调用。使用此方法配置HTTP请求管道。
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())  //开发者特有设置
            {
                app.UseDeveloperExceptionPage();  // 使用开发人员异常页面
                app.UseSwagger();  // 使用帮助文档
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASP.NETCoreWebAPI案例 v1"));  // 帮助文档UI
            }

            app.UseHttpsRedirection();  // 使用Https重定向

            app.UseRouting();  // 使用路由

            app.UseAuthorization();  // 使用授权

            app.UseEndpoints(endpoints =>  // 使用端点
            {
                endpoints.MapControllers();  // Map控制器
            });
        }
    }
}
