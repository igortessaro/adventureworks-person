using AdventureWorks.Person.Domain.Services;
using AdventureWorks.Person.Domain.Services.Abstraction;
using AdventureWorks.Person.Infrastructure.Repositories.Relational;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
            string connectionString = this.Configuration.GetConnectionString("PersonDbConnection");
            _ = services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            _ = services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdventureWorks.Person.Api", Version = "v1" }));
            _ = services.AddPersonContext(connectionString);
            _ = services.AddInfrastructureRepositories();
            _ = services.AddInfrastructureAutoMapper();
            _ = services.AddTransient<IPersonService, PersonService>();
            _ = services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("AdventureWorks.Person")).ToArray());
            _ = services.AddHealthChecks()
                .AddSqlServer(connectionString)
                .AddDbContextCheck<PersonContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _ = app.UseDeveloperExceptionPage();
            _ = app.UseSwagger();
            _ = app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdventureWorks.Person.Api v1"));
            _ = app.UseHttpsRedirection();
            _ = app.UseRouting();
            _ = app.UseAuthorization();
            _ = app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    ResponseWriter = WriteResponse
                });
                endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions()
                {
                    Predicate = (check) => check.Tags.Contains("ready"),
                });
                endpoints.MapHealthChecks("/health/live", new HealthCheckOptions()
                {
                    Predicate = (_) => false
                });
            });
        }

        private static Task WriteResponse(HttpContext context, HealthReport result)
        {
            context.Response.ContentType = "application/json; charset=utf-8";

            var options = new JsonWriterOptions
            {
                Indented = true
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = new Utf8JsonWriter(stream, options))
                {
                    writer.WriteStartObject();
                    writer.WriteString("status", result.Status.ToString());
                    writer.WriteStartObject("results");

                    foreach (var entry in result.Entries)
                    {
                        writer.WriteStartObject(entry.Key);
                        writer.WriteString("status", entry.Value.Status.ToString());
                        writer.WriteString("description", entry.Value.Description);
                        writer.WriteStartObject("data");
                        foreach (var item in entry.Value.Data)
                        {
                            writer.WritePropertyName(item.Key);
                            JsonSerializer.Serialize(
                                writer, item.Value, item.Value?.GetType() ??
                                typeof(object));
                        }

                        writer.WriteEndObject();
                        writer.WriteEndObject();
                    }

                    writer.WriteEndObject();
                    writer.WriteEndObject();
                }

                var json = Encoding.UTF8.GetString(stream.ToArray());

                return context.Response.WriteAsync(json);
            }
        }
    }
}
