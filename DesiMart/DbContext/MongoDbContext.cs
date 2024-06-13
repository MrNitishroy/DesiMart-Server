using DesiMart.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using System;

namespace DesiMart.DbContext
{
    public class MongoDbContext
    {
        private readonly IMongoCollection<Product> _product;
        private readonly IMongoCollection<Customer> _customer;
        private readonly IMongoCollection<Order> _order;
        private readonly IMongoCollection<OrderItem> _orderItem;
        private readonly IMongoCollection<Review> _review;
        public MongoDbContext(IOptions<MongoDbConfigs> mongoDBSettings)
        {
            try
            {
              
                var settings = mongoDBSettings.Value;
                MongoClientSettings clientSettings = MongoClientSettings.FromConnectionString(settings.ConnectionString);
                MongoClient client = new MongoClient(clientSettings);
                IMongoDatabase database = client.GetDatabase(settings.Database);
                _product = database.GetCollection<Product>(settings.ProductsCollection);
                _customer = database.GetCollection<Customer>(settings.CustomerCollection);
                _review = database.GetCollection<Review>(settings.ReviewCollection);
                _order = database.GetCollection<Order>(settings.OrderCollection);
                Console.WriteLine("MongoDB connection established successfully.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error initializing MongoDbContext: {ex.Message}");
                throw; 
            }
        }

        // Exposes the Product collection
        public IMongoCollection<Product> ProductDb => _product;
        public IMongoCollection<Customer> CustomerDb => _customer;
        public IMongoCollection<Review> ReviewDb => _review;
        public IMongoCollection<Order> OrderDb => _order;
    }
}

