using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Core.IRepo
{
    public interface IUnitOfWork
    {
        public ICategoryRepo _categoryRepo { get;}
        public IProductRepo _productRepo { get;}
    }
}
