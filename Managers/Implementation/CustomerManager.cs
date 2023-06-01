using My_Project_Continued.Managers.Interface;
using My_Project_Continued.Models;
using My_Project_Continued.Models.Enums;

namespace My_Project_Continued.Managers.Implementation
{
     public class CustomerManager : ICustomerManager
     {
        public static List<Customer> CustomerDb = new List<Customer>();
     //    {
     //      new Customer(1, 3, Location.Lagos_State, "anu@gmail.com", false, DateTime.Now)
     //    };
          public Customer Get(string email)
          {
               foreach (var customer in CustomerDb)
               {
                    if(customer.UserEmail == email)
                    {
                        return customer;
                    }
               }
               return null;
          }

          public List<Customer> GetAll()
          {
               return CustomerDb;
          }

          public Customer Open(string firstName, string lastName, Location location, string email, string phoneNumber, Gender gender, int walletPin, string password)
          {
               var CustomerCheck = CheckCustomer(email);
               if(CustomerCheck) 
               {
                    return null;
               }

               Customer customer = new Customer(CustomerDb.Count+1, UserManager.UserDb.Count+1, location, email, false, DateTime.Now);
               CustomerDb.Add(customer);

               User user = new User(UserManager.UserDb.Count+1, firstName, lastName, location, email, phoneNumber, "Customer", gender, WalletType.Customer, password, false, DateTime.Now);
               UserManager.UserDb.Add(user);

               Wallet wallet = new Wallet(WalletManager.WalletDb.Count+1, $"{firstName} {lastName}", GenWaltId(), 0, walletPin, WalletType.Customer, location, false, DateTime.Now);
               WalletManager.WalletDb.Add(wallet);

               return customer;
          }
          private bool CheckCustomer(string email)
          {
            foreach (var customer in CustomerDb)
            {
                if(customer.UserEmail == email)
                {
                    return true;
                }
            }
            return false;
          }

          private string GenWaltId()
          {
             return $"WALTID/NBV/00{WalletManager.WalletDb.Count+1}";
          }
     }
}