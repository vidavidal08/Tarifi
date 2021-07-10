using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NicosApp.API.Middleware;
using NicosApp.Core.Feactures.Nicos.Commands.CreateCSVNicos;
using NicosApp.Core.Feactures.Fraccion.Querys.GetNicoList;
using NicosApp.Core.Mappings;
using NicosApp.Infraestructura;
using System.Reflection;
using NicosApp.Core.Interfaces.Identity;
using NicosApp.API.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using NicosApp.API.Helpers;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace NicosApp.API
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

            services.AddControllers(options =>
            {
                options.Conventions.Add(new GroupingByNamespaceConvention());
            })
                .AddNewtonsoftJson(options =>
                {

                    //options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    //options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                })
                .AddFluentValidation(
                            cfg => cfg.RegisterValidatorsFromAssemblyContaining<CreateNicosCSVCommandHandle>());

            services.AddHttpContextAccessor();



            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>()
            .AddScoped<IUrlHelper>(
        serviceProvider => new UrlHelper(
            serviceProvider.GetRequiredService<IActionContextAccessor>()
                .ActionContext
        )
    );


            services.AddInfrastructureServices(Configuration);


            #region API Versioning  
            services.AddApiVersioning(options =>
            { // Specify the default API Version as 1.0
                options.DefaultApiVersion = new ApiVersion(1, 0);
                // If the client hasn't specified the API version in the request, use the default API version number 
                options.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                options.ReportApiVersions = true;
            });
            #endregion


            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "NicosApp.API",
                    Version = "v1",
                    Description = "Web API para consultar los NICOs",
                    License = new OpenApiLicense()
                    {
                        Name = "MIT"
                    }
                });
                c.DocumentFilter<DocumentFilter>();
            });





            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new NicoProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);




            services.AddMediatR(typeof(GetFraccionArancelariaListQuery).Assembly);
            services.AddMediatR(Assembly.GetExecutingAssembly());



            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddSingleton<ISchemaAcountUrlConfirmEmailService, SchemaAcountUrlConfirmEmailService>();


            services.AddCors();


            //services.AddMvc();

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("StrONGKAutHENTICATIONKEy"));
            // services.AddMvc();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {

           // app.UseMiddleware<ManejadorErrorMiddleware>();
            app.UseMiddleware<ErrorHandlerMiddleware>();

            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();

            }


            app.UseSwagger();
           
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName);
                    }
                });

            app.UseHttpsRedirection();

            app.UseRouting();

          //  app.UseCors("CorsRule");


            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials


            app.UseAuthentication();
            app.UseAuthorization();

            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
