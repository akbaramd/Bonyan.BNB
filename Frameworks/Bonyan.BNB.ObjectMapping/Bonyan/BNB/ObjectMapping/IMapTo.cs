namespace Bonyan.BNB.ObjectMapping;

public interface IMapTo<TDestination>
{
    TDestination MapTo();

    void MapTo(TDestination destination);
}
