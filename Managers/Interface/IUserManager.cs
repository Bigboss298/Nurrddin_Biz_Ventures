using My_Project_Continued.Models;

namespace My_Project_Continued.Managers.Interface
{
    public interface IUserManager
    {
        User Get(string email);
        List<User> GetAll();
        User Login(string email, string password);
    }
}