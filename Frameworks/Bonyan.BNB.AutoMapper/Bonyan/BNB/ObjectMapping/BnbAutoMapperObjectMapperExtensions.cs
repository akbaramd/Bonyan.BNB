using AutoMapper;
using Bonyan.BNB.AutoMapper;

namespace Bonyan.BNB.ObjectMapping;

public static class BnbAutoMapperObjectMapperExtensions
{
    public static IMapper GetMapper(this IObjectMapper objectMapper)
    {
        return objectMapper.AutoObjectMappingProvider.GetMapper();
    }

    public static IMapper GetMapper(this IAutoObjectMappingProvider autoObjectMappingProvider)
    {
        if (autoObjectMappingProvider is AutoMapperAutoObjectMappingProvider autoMapperAutoObjectMappingProvider)
        {
            return autoMapperAutoObjectMappingProvider.MapperAccessor.Mapper;
        }

        throw new Exception($"Given object is not an instance of {typeof(AutoMapperAutoObjectMappingProvider).AssemblyQualifiedName}. The type of the given object it {autoObjectMappingProvider.GetType().AssemblyQualifiedName}");
    }
}
