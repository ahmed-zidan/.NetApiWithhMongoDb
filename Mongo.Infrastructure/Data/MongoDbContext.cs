using Microsoft.Extensions.Configuration;
using Mongo.Core.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Infrastructure.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;
        public MongoDbContext(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDbSettings:ConnectionString"]);
            _database = client.GetDatabase(config["MongoDbSettings:DatabaseName"]);
        }

        public IMongoCollection<Category> _categories => _database.GetCollection<Category>("Categories");
        public IMongoCollection<Product> _product => _database.GetCollection<Product>("Products");
    }
}
