using Entities;
using MongoFramework;

namespace EFCData;

public class MongoContext : MongoDbContext
{
    public MongoContext(IMongoDbConnection connection) : base(connection) { }
    
    public MongoDbSet<MongoUser>? Users { get; set; }
    
    // protected override void OnConfigureMapping(MappingBuilder mappingBuilder)
    // {
    //     mappingBuilder.Entity<MongoUser>()
    //         .HasProperty(m => m.first_name, b => b.HasElementName("first_name"))
    //         .ToCollection("mongo_users");
    // }
}