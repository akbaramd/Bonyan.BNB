using AutoMapper;

namespace Bonyan.BNB.AutoMapper;

internal class MapperAccessor : IMapperAccessor
{
    public IMapper Mapper { get; set; } = default!;
}
