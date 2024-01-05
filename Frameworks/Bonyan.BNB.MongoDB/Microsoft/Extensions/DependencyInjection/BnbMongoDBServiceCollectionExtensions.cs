using Bonyan.BNB.DDD.Domain.MongoDb;
using Bonyan.BNB.DDD.Domain.Repository;
using Bonyan.BNB.MongoDb;
using MongoDB.Driver;

namespace Microsoft.Extensions.DependencyInjection;

public static class BnbMongoDbServiceCollectionExtensions
{
    public static void AddMongoDb(
        this IServiceCollection services,
        Action<EntMongoDbOptions> configure)

    {
        var option = new EntMongoDbOptions();
        configure.Invoke(option);

        var mongoClient = new MongoClient(
            option.Uri);

        var mongoDatabase = mongoClient.GetDatabase(
            option.Database);

        services.AddScoped<IMongoClient>(sp => mongoClient);
        services.AddScoped<IMongoDatabase>(sp => mongoDatabase);
        services.AddScoped(typeof(IReadOnlyRepository<,>),typeof(BnbMongoRepository<,>));
        services.AddScoped(typeof(IRepository<,>),typeof(BnbMongoRepository<,>));
        services.AddScoped(typeof(IMongoReadonlyRepository<,>),typeof(BnbMongoRepository<,>));
        services.AddScoped(typeof(IReadOnlyRepository<,>),typeof(BnbMongoRepository<,>));
        services.AddScoped<IMongoDatabase>(sp => mongoDatabase);
        
    }
    
   

}