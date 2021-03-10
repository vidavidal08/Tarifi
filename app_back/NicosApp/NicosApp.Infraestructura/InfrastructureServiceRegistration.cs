using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NicosApp.Core.Entidades;
using NicosApp.Core.Interfaces.Files;
using NicosApp.Core.Interfaces.Identity;
using NicosApp.Core.Interfaces.Repositorios;
using NicosApp.Core.Interfaces.Repositorios.Base;
using NicosApp.Infraestructura.Data;
using NicosApp.Infraestructura.Files;
using NicosApp.Infraestructura.Identity;
using NicosApp.Infraestructura.Notificacion.Email;
using NicosApp.Infraestructura.Repositorios;
using NicosApp.Infraestructura.Repositorios.Base;
using System.Text;

namespace NicosApp.Infraestructura
{
    public static class InfrastructureServiceRegistration
    {


        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {




            services.AddDbContext<NicosAppContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("DefaultConnnection")));



            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })


            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            });


            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<NicosAppContext>()
                    .AddDefaultTokenProviders();



            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                //options.SignIn.RequireConfirmedPhoneNumber = false;




                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = true;

            });




            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));





            services.AddTransient<IFraccionArancelariaRepositorio, FraccionArancelariaRepositorio>();
            services.AddTransient<INicoRepositorio, NicoRepositorio>();
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();

            services.AddTransient<IJwtGenerador, JwtGenerador>();


            services.AddTransient<ICsvNicosFileBuilder, CsvNicosFileBuilder>();
            services.AddTransient<ICsvFraccionFileBuilder, CsvFraccionFileBuilder>();




            services.AddEmailNotification(configuration);

            return services;

        }

    }
}
