namespace Bonyan.Bnb.Modularity;

public interface IOnPreApplicationInitialization
{
    Task OnPreApplicationInitializationAsync(BnbApplicationInitializationContext context);

    void OnPreApplicationInitialization(BnbApplicationInitializationContext context);
}
