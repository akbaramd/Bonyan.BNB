namespace Bonyan.Bnb.Modularity;

public interface IOnPostBnbApplicationInitialization
{
    Task OnPostApplicationInitializationAsync(BnbApplicationInitializationContext context);

    void OnPostApplicationInitialization(BnbApplicationInitializationContext context);
}
