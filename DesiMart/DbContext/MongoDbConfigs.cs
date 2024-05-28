namespace DesiMart.DbContext
{
    public class MongoDbConfigs
    {
        public const string Option = "MongoDbConfigs";
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public bool EnableCommandTracing { get; set; }
    }
}
