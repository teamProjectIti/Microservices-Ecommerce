
namespace Data.Entities.Connection
{
   public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
