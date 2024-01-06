using AutoMapper;

namespace Bonyan.BNB.AutoMapper;

public interface IBnbAutoMapperConfigurationContext
{
    IMapperConfigurationExpression MapperConfiguration { get; }

    IServiceProvider ServiceProvider { get; }
}
