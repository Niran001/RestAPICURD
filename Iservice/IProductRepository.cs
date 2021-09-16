using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestAPICrud.Models;

namespace RestAPICrud.Iservice
{
    interface IProductRepository
    {

        FunctionResponse GetAllDetail();
        FunctionResponse Insert(Product product);
        FunctionResponse Update(Product product);
        FunctionResponse Delete(int id);

    }
}

