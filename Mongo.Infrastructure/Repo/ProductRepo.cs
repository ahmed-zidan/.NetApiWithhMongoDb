using Mongo.Core.Models;
using Mongo.Infrastructure.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Infrastructure.Repo
{
    public class ProductRepo
    {
        private readonly MongoDbContext _dbContext;
        public ProductRepo(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> getProducts(){

            var pipline = new BsonDocument[]
            {
                new BsonDocument("$lookup" , new BsonDocument
                {
                    { "from", "Categories" }, // The category collection
                    { "localField", "CategoryId" }, // Field from Product
                    { "foreignField", "_id" }, // Field from Category
                    { "as", "product_category" } // Output array field
                }),
                new BsonDocument("$unwind" , "$product_category"),
                new BsonDocument("$project" , new BsonDocument
                {
                    {"_id" , 1 },
                    {"CategoryId" , 1},
                    {"ProductName" , 1 },
                    {"CategoryName","$product_category.Name" }
                }

                )

            };
            return await _dbContext._categories.Aggregate<Product>(pipline).ToListAsync();

        
        } 
    }
}
