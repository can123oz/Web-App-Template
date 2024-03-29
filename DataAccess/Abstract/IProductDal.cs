﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //code refactoring
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductsDetails();
    }
}
