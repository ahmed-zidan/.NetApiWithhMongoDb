using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Core.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string CategoryId { get; set; }
    }
}
