using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.IdentityModel.Tokens;
using SurveyBasket_VerticalSlice.Domain.Identity;
using SurveyBasket_VerticalSlice.Features.Authentication.Shared;
using System.Text;
using Serilog; 
namespace SurveyBasket_VerticalSlice
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesConfigration(this IServiceCollection services, IConfiguration configuration)
        {

            //CorsOrigin
            var allowOrigin = configuration.GetSection("AllowedOrigins").Get<string[]>();
            services.AddCors(option =>
            {
                option.AddDefaultPolicy(opt =>
                {
                    opt
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins(allowOrigin!);
                });
            });

            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddMediatRConfiguration();
            services.AddMapsterConfigration();
            services.AddFluenentValidtionConfigration();
            services.AddAutoMapperConfigration();
            services.AddIdentityConfigration(configuration);
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<RequestParameters>();
            services.AddScoped<ControllerParamters>();
            return services;
        }

        private static IServiceCollection AddMediatRConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
        private static IServiceCollection AddMapsterConfigration(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton<MapsterMapper.IMapper>(new MapsterMapper.Mapper(config));
            return services;
        }
        private static IServiceCollection AddFluenentValidtionConfigration(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
        private static IServiceCollection AddAutoMapperConfigration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
        private static IServiceCollection AddIdentityConfigration(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                        .AddEntityFrameworkStores<ApplicationDbContext>()
                        .AddDefaultTokenProviders();
            // binding 
           services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));
            services.Configure<MailSetting>(configuration.GetSection(nameof(MailSetting)));
            services.AddScoped<IEmailSender, EmailService>();

            var jwtSettings = configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(opt =>
                {
                    opt.SaveToken = true;
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidIssuer = jwtSettings?.ValidIssuer ,
                        ValidAudience = jwtSettings?.ValidAudiance,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings?.Key!))
                    };
                });

            services.AddHttpContextAccessor();

            services.Configure<IdentityOptions>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequiredLength = 8;
                opt.SignIn.RequireConfirmedAccount = true;
            });  

            return services;
        }
        
        
        
    }
}
