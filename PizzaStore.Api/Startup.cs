using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PizzaStoreAPi.Repositories;
using SD.LLBLGen.Pro.DQE.SqlServer;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace PizzaStoreAPi
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
            ConfigureLlbl(Configuration);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "PizzaStoreAPi", Version = "v1"});
            });
            services.AddSingleton<IPizzaRepository, PizzaRepository>();
            services.AddSingleton<IToppingRepository, ToppingRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStoreAPi v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
        
        private void ConfigureLlbl(IConfiguration config)
        {
            string cs = config.GetConnectionString("PizzaStore");
            RuntimeConfiguration.AddConnectionString("ConnectionString.SQL Server (SqlClient)", cs);
            RuntimeConfiguration.ConfigureDQE<SQLServerDQEConfiguration>(c =>
            {
                c.AddDbProviderFactory(typeof(SqlClientFactory));
                c.SetTraceLevel(TraceLevel.Verbose);
            });
        }
    }
}