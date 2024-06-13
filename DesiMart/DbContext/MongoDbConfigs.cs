namespace DesiMart.DbContext
{
    public class MongoDbConfigs
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string ProductsCollection { get; set; }
        public string CustomerCollection { get; set; }
        public string OrderCollection { get; set; }
        public string ReviewCollection { get; set; }
        public string OrderItemCollection { get; set; }
        public string CategoryCollection { get; set; }
    }
}
