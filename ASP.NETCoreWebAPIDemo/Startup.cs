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
    /// Startup��������
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // �˷���������ʱ���á�ʹ�ô˷�������������ӷ���
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP.NETCoreWebAPI����", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // �˷���������ʱ���á�ʹ�ô˷�������HTTP����ܵ���
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())  //��������������
            {
                app.UseDeveloperExceptionPage();  // ʹ�ÿ�����Ա�쳣ҳ��
                app.UseSwagger();  // ʹ�ð����ĵ�
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASP.NETCoreWebAPI���� v1"));  // �����ĵ�UI
            }

            app.UseHttpsRedirection();  // ʹ��Https�ض���

            app.UseRouting();  // ʹ��·��

            app.UseAuthorization();  // ʹ����Ȩ

            app.UseEndpoints(endpoints =>  // ʹ�ö˵�
            {
                endpoints.MapControllers();  // Map������
            });
        }
    }
}
