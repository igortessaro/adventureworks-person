using AdventureWorks.Person.Domain.Services;
using AdventureWorks.Person.Domain.Services.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;

namespace AdventureWorks.Person.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            _ = services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdventureWorks.Person.Api", Version = "v1" }));
            _ = services.AddPersonContext(this.Configuration.GetConnectionString("PersonDbConnection"));
            _ = services.AddInfrastructureRepositories();
            _ = services.AddInfrastructureAutoMapper();
            _ = services.AddTransient<IPersonService, PersonService>();
            _ = services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("AdventureWorks.Person")).ToArray());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _ = app.UseDeveloperExceptionPage();
            _ = app.UseSwagger();
            _ = app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdventureWorks.Person.Api v1"));
            _ = app.UseHttpsRedirection();
            _ = app.UseRouting();
            _ = app.UseAuthorization();
            _ = app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
