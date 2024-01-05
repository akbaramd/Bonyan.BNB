using Bonyan.BNB.DDD.Domain.MongoDb;
using Bonyan.Example.Domain.Aggregates.Products;
using MongoDB.Driver;

namespace Bonyan.Example.Infrastructure.Mongo.Repositories;

public class ProductRepository(IMongoDatabase mongoDatabase) : BnbMongoRepository<Product,Guid>(mongoDatabase), IProductRepository
{
    
}