using Mongo.Core.IRepo;
using Mongo.Core.Models;
using Mongo.Infrastructure.Data;
using MongoDB.Driver;
using MongoDB.Driver.Linq;


namespace Mongo.Infrastructure.Repo
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly MongoDbContext _dbContext;
        public CategoryRepo(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddCategoryAsync(Category category)
        {
            await _dbContext._categories.InsertOneAsync(category);
        }

       
        public async Task DeleteCategoryAsync(Category category)
        {
            await _dbContext._categories.DeleteOneAsync(x => x.Id == category.Id);
            
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _dbContext._categories.Find(_ => true).ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(string id)
        {
            return await _dbContext._categories.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            var cat = await _dbContext._categories.FindOneAndReplaceAsync(x => x.Id == category.Id, category);
            return cat; 
        }
    }
}
