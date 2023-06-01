using My_Project_Continued.Models;
using My_Project_Continued.Models.Enums;

namespace My_Project_Continued.Managers.Interface
{
    public interface IBranchManager
    {
        Branch Get(Location location);
        List<Branch> GetAll();      
        Branch Add(Location branchLocation, string firstName, string lastName, string email, string phoneNumber, Gender gender, string password, int walletPin);
    }
}