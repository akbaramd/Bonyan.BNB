using AutoMapper;

namespace Bonyan.BNB.AutoMapper;

public class BnbAutoMapperConfigurationContext : IBnbAutoMapperConfigurationContext
{
    public IMapperConfigurationExpression MapperConfiguration { get; }

    public IServiceProvider ServiceProvider { get; }

    public BnbAutoMapperConfigurationContext(
        IMapperConfigurationExpression mapperConfigurationExpression,
        IServiceProvider serviceProvider)
    {
        MapperConfiguration = mapperConfigurationExpression;
        ServiceProvider = serviceProvider;
    }
}
