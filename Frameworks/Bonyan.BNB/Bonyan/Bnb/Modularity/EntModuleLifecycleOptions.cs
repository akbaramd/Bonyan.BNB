using Bonyan.Bnb.Collections;

namespace Bonyan.Bnb.Modularity;

public class BnbModuleLifecycleOptions
{
    public ITypeList<IBnbModuleLifecycleContributor> Contributors { get; }

    public BnbModuleLifecycleOptions()
    {
        Contributors = new TypeList<IBnbModuleLifecycleContributor>();
    }
}
