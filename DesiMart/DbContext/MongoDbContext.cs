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
        public MongoDbContext(IOptions<MongoDbConfigs> mongoDBSettings)
        {
            try
            {
                // Extract the connection settings
                var settings = mongoDBSettings.Value;

                // Initialize MongoClient settings from the connection string
                MongoClientSettings clientSettings = MongoClientSettings.FromConnectionString(settings.ConnectionString);

                // Create MongoClient instance
                MongoClient client = new MongoClient(clientSettings);

                // Get the specified database
                IMongoDatabase database = client.GetDatabase(settings.Database);

                // Get the collection for Product
                _product = database.GetCollection<Product>(settings.ProductsCollection);

                // Optional: Log successful connection
                Console.WriteLine("MongoDB connection established successfully.");
            }
            catch (Exception ex)
            {
                // Handle potential errors and optionally log them
                Console.Error.WriteLine($"Error initializing MongoDbContext: {ex.Message}");
                throw; // Re-throw the exception after logging
            }
        }

        // Exposes the Product collection
        public IMongoCollection<Product> ProductDb => _product;
    }
}

