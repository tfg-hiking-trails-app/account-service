using AccountService.API.DTOs.Mapping;
using AccountService.API.Workers;
using AccountService.Application.Interfaces;
using AccountService.Application.Services;
using AccountService.Domain.Interfaces;
using AccountService.Infrastructure.Data;
using AccountService.Infrastructure.Data.Configurations.Mapping;
using AccountService.Infrastructure.Data.Repositories;
using AccountService.Infrastructure.Messaging.Consumer;
using Common.API.DTOs.Mapping;
using Common.Application.Interfaces;
using Common.Application.Services;
using Common.Domain.Interfaces.Messaging;
using Common.Infrastructure.Data.Configuration.Mapping;
using Common.Infrastructure.Messaging.Configuration;
using Common.Infrastructure.Security.Tokens;
using Microsoft.OpenApi.Models;

namespace AccountService.API.Extensions;

public static class ServiceCollectionExtension
{
    public static void ServiceCollectionConfiguration(this IServiceCollection services)
    {
        services.AddRouting(options => options.LowercaseUrls = true);

        services.AddDbContext<AccountServiceDbContext>();
        
        services.AddAutoMapper();
        
        services.AddRabbitMq();
        
        services.AddHostedServices();
        
        services.AddServices();
        
        services.AddRepositories();
        
        services.AddSwaggerGen();
    }
    
    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IEventConsumerService, EventConsumerService>();
        services.AddScoped<ITokenManager, TokenManager>();
        services.AddScoped<IGenderService, GenderService>();
        services.AddScoped<IAccountService, Application.Services.AccountService>();
        services.AddScoped<IAccountFollowService, AccountFollowService>();
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<IRegionService, RegionService>();
        services.AddScoped<ISubregionService, SubregionService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<IStateService, StateService>();
        services.AddScoped<ICityService, CityService>();
    }
    
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IGenderRepository, GenderRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IAccountFollowRepository, AccountFollowRepository>();
        services.AddScoped<IRegionRepository, RegionRepository>();
        services.AddScoped<ISubregionRepository, SubregionRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IStateRepository, StateRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
    }
    
    private static void AddHostedServices(this IServiceCollection services)
    {
        services.AddHostedService<Worker>();
    }
    
    private static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(CommonProfile).Assembly,
            typeof(GenderProfile).Assembly,
            typeof(AccountProfile).Assembly,
            typeof(AccountFollowProfile).Assembly,
            typeof(RegionProfile).Assembly,
            typeof(SubregionProfile).Assembly,
            typeof(CountryProfile).Assembly,
            typeof(StateProfile).Assembly,
            typeof(CityProfile).Assembly,
            typeof(CommonEntityProfile).Assembly,
            typeof(GenderEntityProfile).Assembly,
            typeof(AccountEntityProfile).Assembly,
            typeof(RegionEntityProfile).Assembly,
            typeof(SubregionEntityProfile).Assembly,
            typeof(CountryEntityProfile).Assembly,
            typeof(StateEntityProfile).Assembly,
            typeof(CityEntityProfile).Assembly,
            typeof(AccountFollowEntityProfile).Assembly);
    }
    
    private static void AddRabbitMq(this IServiceCollection services)
    {
        // Providers
        services.AddScoped<IRabbitMqConnectionProvider, RabbitMqConnectionProvider>();
        services.AddScoped<IRabbitMqChannelProvider, RabbitMqChannelProvider>();
        services.AddScoped<IRabbitMqQueueProvider, RabbitMqQueueProvider>();
        
        // Processors
        services.AddScoped<IRabbitMqQueueConsumer, RabbitMqQueueConsumer>();
    }
    
    private static void AddSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "Accounts Microservice", 
                Version = "3.0.1"
            });
        });
    }
    
}