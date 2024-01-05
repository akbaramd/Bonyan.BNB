using AutoMapper;
using AutoMapper.Internal;
using Bonyan.Bnb.Attributes;
using Bonyan.Bnb.Modularity;
using Bonyan.BNB.ObjectMapping;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Bonyan.BNB.AutoMapper;

[DependsOnModules(
    typeof(BnbObjectMappingModule)
)]
public class BnbAutoMapperModule : BnbModule
{
    public override void PreConfigureServices(BnbServiceConfigurationContext context)
    {
        context.Services.AddConventionalRegistrar(new AbpAutoMapperConventionalRegistrar());
    }

    public override void ConfigureServices(BnbServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper();

        context.Services.AddSingleton<IConfigurationProvider>(sp =>
        {
            using (var scope = sp.CreateScope())
            {
                var options = scope.ServiceProvider.GetRequiredService<IOptions<AbpAutoMapperOptions>>().Value;

                var mapperConfigurationExpression = sp.GetRequiredService<IOptions<MapperConfigurationExpression>>().Value;
                var autoMapperConfigurationContext = new AbpAutoMapperConfigurationContext(mapperConfigurationExpression, scope.ServiceProvider);

                foreach (var configurator in options.Configurators)
                {
                    configurator(autoMapperConfigurationContext);
                }
                var mapperConfiguration = new MapperConfiguration(mapperConfigurationExpression);

                foreach (var profileType in options.ValidatingProfiles)
                {
                    mapperConfiguration.Internal().AssertConfigurationIsValid(((Profile)Activator.CreateInstance(profileType)).ProfileName);
                }

                return mapperConfiguration;
            }
        });

        context.Services.AddTransient<IMapper>(sp => sp.GetRequiredService<IConfigurationProvider>().CreateMapper(sp.GetService));

        context.Services.AddTransient<MapperAccessor>(sp => new MapperAccessor()
        {
            Mapper = sp.GetRequiredService<IMapper>()
        });
        context.Services.AddTransient<IMapperAccessor>(provider => provider.GetRequiredService<MapperAccessor>());
    }
}
