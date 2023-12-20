namespace Bonyan.Bnb;

public interface IBnbApplicationWithInternalServiceProvider : IBnbApplication
{
    
    IServiceProvider CreateServiceProvider();

    Task InitializeAsync();

    void Initialize();
}
