using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    //Every class has to get an inheritance.
    public class Category : IEntity
    {
        public int CategorytId { get; set; }
        public string CategoryName { get; set; }
    }
}
