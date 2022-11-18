using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Api
{
    public class ApiConstants
    {
        public const string BaseUri = "api";
        public const string ProductIdParam = "{customerId:int:min(0)}";

        public const string CustomersUri = "customers";
        public const string ProductsUri = "products";
    }
}
