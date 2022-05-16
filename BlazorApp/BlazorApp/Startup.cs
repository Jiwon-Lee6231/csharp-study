using BlazorApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();

            // Dependency Injection
            services.AddSingleton<IFoodService, FastFoodService>();
            // 생성자에서 알아서 연결해준다
            services.AddSingleton<PaymentService>();

            // 3가지 모드
            // 싱글턴 - 서버가 한번 실행되었을 때 한 번 만들어지고 변화 없이 쭉 감.
            //          단, 클라이언트 블레이저에선 계속 새로 만들어짐.
            //          변동 없이 쭉 같은 값을 보여줘야 한다면
            // 트랜지언트 - 요청을 할 때마다 계속 변함.
            // 스콥트 - 접속이 이루어졌을 때 새로 바뀌기 때문에 같은 페이지인 경우 변화 없음.
            services.AddSingleton<SingletonService>();
            services.AddTransient<TransientService>();
            services.AddScoped<ScopedService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
