using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
        public static string GeneralErrorMessage = "An Error Pops";
        public static string NameTakenError = "Name has taken";
        public static string SuccessMessage = "Successfuly returned";
        public static string AuthorizationDenied = "Not Authorized For this action";
        public static string UserRegistered = "User Registered Successfuly";
        public static string PasswordError = "Incorrect Password";
        public static string UserNotFound = "User Cant Found";
        public static string SuccessfulLogin = "Logged in Successfuly";
        public static string UserAlreadyExists = "User already exist";
        public static string AccessTokenCreated = "Access Token Created";
    }
}
