using Mongo.Core.IRepo;
using Mongo.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Infrastructure.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MongoDbContext _context;
        public UnitOfWork(MongoDbContext context)
        {
            _context = context;
        }
        public ICategoryRepo _categoryRepo => new CategoryRepo(_context);

        public IProductRepo _productRepo => throw new NotImplementedException();
    }
}
