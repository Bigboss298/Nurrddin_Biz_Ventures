using My_Project_Continued.Models;
using My_Project_Continued.Models.Enums;

namespace My_Project_Continued.Managers.Interface
{
    public interface ICustomerManager
    {
        Customer Get(string email);
        List<Customer> GetAll();
        Customer Open(string firstName, string lastName, Location location, string email, string phoneNumber, Gender gender, int walletPin, string password);
    }
}