using SurveyBasket_VerticalSlice.Comman;
using SurveyBasket_VerticalSlice.Repository;

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
    }
}
