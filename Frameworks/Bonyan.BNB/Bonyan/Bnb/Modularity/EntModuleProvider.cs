namespace Bonyan.Bnb.Modularity;

public class BnbModuleProvider :   IBnbModuleProvider
{

    private Dictionary<string, BnbModule> _registeredModule = new Dictionary<string, BnbModule>();
    
    

    public void Register<T>(T module) where T : BnbModule
    {
        if (!Exists(module))
        {
            _registeredModule.Add(module.GetType().Name,module);
        }
    }

    

    public bool Exists<T>(T module) where T : BnbModule
    {
        return Exists(module.GetType().Name);
    }

    public bool Exists(string moduleKey)
    {
        return _registeredModule.Any(x => x.Key == moduleKey);
    }
}