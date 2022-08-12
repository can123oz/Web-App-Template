using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{ 
    //no need to write always new() thats why static.
    public static class Messages
    {
        public static string ProductAdded = "Product Added";
        public static string ProductNameInvalid = "Invalid Name";
        public static string MaintenanceTime = "Maintenance time";
        public static string ProductsListed = "Products Listed";
        public static string NotFound = "Not Found";
    }
}
