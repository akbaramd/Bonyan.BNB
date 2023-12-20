namespace Bonyan.Bnb.Modularity;

public interface IBnbModuleProvider
{
    public void Register<T>(T module) where T : BnbModule;
    
    public bool Exists<T>(T module) where T : BnbModule;
    public bool Exists(string moduleKey);

}