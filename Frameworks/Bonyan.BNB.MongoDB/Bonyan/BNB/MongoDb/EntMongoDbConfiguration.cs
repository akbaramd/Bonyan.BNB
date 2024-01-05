using Bonyan.BNB.DDD.Domain.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Bonyan.BNB.MongoDb;

public class EntMongoDbConfiguration
{
   protected IServiceCollection Services { get; set; }

   public EntMongoDbConfiguration(IServiceCollection services)
   {
      Services = services;
   }
   
   public EntMongoDbOptions Options { get; set; } = new EntMongoDbOptions();


 
}