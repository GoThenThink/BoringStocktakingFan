using BSF.BLL;
using BSF.DAL;
using BSF.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BSF
{
    /// <summary/>
    public class Startup
    {
        /// <summary/>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary/>
        public IConfiguration Configuration { get; }

        /// <summary/>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services
                .AddDataAccessLayer(Configuration.GetConnectionString("DataBase"))
                .AddBusinessLayer()
                .AddAutoMapper()
                .AddSwagger();
        }

        /// <summary/>
        public void Configure(IApplicationBuilder app)
        {
            app
                .UseRouting()
                .UseSwaggerWithCustomSettings()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
