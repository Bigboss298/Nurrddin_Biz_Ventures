using My_Project_Continued.Managers.Interface;
using My_Project_Continued.Models;
using My_Project_Continued.Models.Enums;

namespace My_Project_Continued.Managers.Implementation
{
     public class UserManager : IUserManager
     {
        public static List<User> UserDb = new List<User>()
        {
               new User(1, "Big", "Boss", Location.Ogun_State, "bigboss@gmail.com", "08155850462", "SuperAdmin", Gender.Male, WalletType.SuperAdmin, "password123", false, DateTime.Now),
     //           new User(2, "Abdullah", "Bisiriyu", Location.Lagos_State, "abdul@gmail.com", "345678", "BranchHead", Gender.Male, WalletType.BranchHead, "pass123", false, DateTime.Now),
     //           new User(3, "Anuoluwa", "Olawale", Location.Oyo_State, "anu@gmail.com", "45678", "Customer", Gender.Male, WalletType.Customer, "passer", false, DateTime.Now),
     //           new User(4, "Abdul", "Mujeeb", Location.Ogun_State, "mujeeb@gmail.com", "456789", "BranchHead", Gender.Male, WalletType.BranchHead, "pass345", false, DateTime.Now),
     //           new User(5, "Adesanya", "Masturah", Location.Osun_State, "masturah@gmail.com", "345678", "BranchHead", Gender.Female, WalletType.BranchHead, "pass456", false, DateTime.Now),
     //           new User(6, "Alpha", "Masroor", Location.Oyo_State, "masroor@gmail.com", "09876", "BranchHead", Gender.Male, WalletType.BranchHead, "pass567", false, DateTime.Now),
        };
          public User Get(string email)
          {
               foreach (var user in UserDb)
               {
                    if(user.Email == email)
                    {
                         return user;
                    }
               }
               return null;
          }

          public List<User> GetAll()
          {
               return UserDb;
          }

          public User Login(string email, string password)
          {
               foreach (var user in UserDb)
               {
                    if(user.Email == email && user.Password == password)
                    {
                         return user;
                    }
               }
               return null;
          }
     }
}