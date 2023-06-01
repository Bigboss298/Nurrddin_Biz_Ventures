using My_Project_Continued.Models.Enums;

namespace My_Project_Continued.Models
{
    public class User : BaseEntity
    {
        public string FirstName;
        public string LastName;
        public Location Location;
        public string Email;
        public string PhoneNumber;
        public string Role;
        public Gender Gender;
        public WalletType WalletType;
        public string Password;

          public User(int id, string firstName, string lastName, Location location, string email, string phoneNumber, string role, Gender gender, WalletType walletType, string password, bool isDeleted, DateTime dateCreated) : base(id, isDeleted, dateCreated)
          {
               FirstName = firstName;
               LastName = lastName;
               Location = location;
               Email = email;
               PhoneNumber = phoneNumber;
               Role = role;
               Gender = gender;
               WalletType = walletType;
               Password = password;
          }

          // public override string ToString()
          // {
          //      return $"{Id}\t{FirstName}\t{LastName}\t{Location}\t{Email}\t{PhoneNumber}\t{Role}\t{Gender}\t{WalletType}\t{Password}\t{IsDeleted}\t{ DateCreated}";
          // }

          // public static User ToUser(string user)
          // {
          //      var userObj = user.Split('\t');
          //      var id = int.Parse(userObj[0]);
          //      var firstName = userObj[1];
          //      var lastName = userObj[2];
          //      var location = Enum.TryParse(userObj[3], out Location loc);
          //      var email = userObj[4];
          //      var phoneNumber = userObj[5];
          //      var role = userObj[6];
          //      var gender = Enum.TryParse(userObj[6], out Gender gend);
          //      var walletType = Enum.TryParse(userObj[7], out WalletType wallet);
          //      var password = userObj[9];
          //      var isDeleted = bool.Parse(userObj[10]);
          //      var dateCreated = DateTime.Parse(userObj[11]);
               
          //      return new User(id, firstName, lastName, loc, email, phoneNumber, role, gend, wallet, password, isDeleted, dateCreated);

          // }
     }
}