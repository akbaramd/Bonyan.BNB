using AutoMapper;

namespace Bonyan.BNB.AutoMapper;

public interface IAbpAutoMapperConfigurationContext
{
    IMapperConfigurationExpression MapperConfiguration { get; }

    IServiceProvider ServiceProvider { get; }
}
