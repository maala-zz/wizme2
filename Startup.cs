using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wizme.Entities;
using Microsoft.EntityFrameworkCore;
using Wizme.Services;

namespace Wizme
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
			var connectionString = Configuration["connectionStrings:VenueDBConnectionString"];
            services.AddDbContext<Context>(o => o.UseSqlServer(connectionString));
            services.AddMvc();
            services.AddScoped<IVenueServices, VenueServices>();
            services.AddScoped<ISpaceServices, SpaceServices>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.Venue, Models.VenueDto>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src =>
                    src.Id))
                    .ForMember(dest => dest.Chain, opt => opt.MapFrom(src =>
                    src.Chain))
                    .ForMember(dest => dest.Brand, opt => opt.MapFrom(src =>
                    src.Brand));

                cfg.CreateMap<Entities.Space, Models.SpaceDto>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src =>
                    src.Id))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src =>
                    src.Price))
                    .ForMember(dest => dest.Shape, opt => opt.MapFrom(src =>
                    src.Shape));
            });
        }
    }
}
