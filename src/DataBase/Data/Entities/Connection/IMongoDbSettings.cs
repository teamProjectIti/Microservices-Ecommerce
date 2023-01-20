
namespace Data.Entities.Connection
{
    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
