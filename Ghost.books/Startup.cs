using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Ghost.books
{
#pragma warning disable CS1591 // O coment�rio XML ausente n�o foi encontrado para o tipo ou membro vis�vel publicamente
    public class Startup
#pragma warning restore CS1591 // O coment�rio XML ausente n�o foi encontrado para o tipo ou membro vis�vel publicamente
    {
#pragma warning disable CS1591 // O coment�rio XML ausente n�o foi encontrado para o tipo ou membro vis�vel publicamente
        public Startup(IConfiguration configuration)
#pragma warning restore CS1591 // O coment�rio XML ausente n�o foi encontrado para o tipo ou membro vis�vel publicamente
        {
            Configuration = configuration;
        }

#pragma warning disable CS1591 // O coment�rio XML ausente n�o foi encontrado para o tipo ou membro vis�vel publicamente
        public IConfiguration Configuration { get; }
#pragma warning restore CS1591 // O coment�rio XML ausente n�o foi encontrado para o tipo ou membro vis�vel publicamente

        // This method gets called by the runtime. Use this method to add services to the container.
#pragma warning disable CS1591 // O coment�rio XML ausente n�o foi encontrado para o tipo ou membro vis�vel publicamente
        public void ConfigureServices(IServiceCollection services)
#pragma warning restore CS1591 // O coment�rio XML ausente n�o foi encontrado para o tipo ou membro vis�vel publicamente
        {
            services.AddControllers();
            _ = services.AddSwaggerGen(c =>
              {
                  var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                  var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                  c.IncludeXmlComments(xmlPath);
              });
        }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseHttpsRedirection();

                app.UseRouting();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/Swagger/v1/swagger.json", "Ghost Book");
                    c.RoutePrefix = string.Empty; //swagger
                });
            }

        }
    }

