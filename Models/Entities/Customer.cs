using My_Project_Continued.Models.Enums;

namespace My_Project_Continued.Models
{
    public class Customer : BaseEntity
    {
        public int UserId;
        public Location Location;
        public  string UserEmail;

          public Customer(int id, int userId, Location location, string userEmail, bool isDeleted, DateTime dateCreated) : base(id, isDeleted, dateCreated)
          {
               UserId = userId;
               Location = location;
               UserEmail = userEmail;
          }

          // public override string ToString()
          // {
          //      return $"{Id}\t{UserId}\t{Location}\t{UserEmail}\t{IsDeleted}\t{DateCreated}";
          // }

          // public static Customer ToCustomerObj(string customer)
          // {
          //      var custObj = customer.Split('\t');
          //      var id  = int.Parse(custObj[0]);
          //      var userId = int.Parse(custObj[1]);
          //      var location = Enum.TryParse(custObj[2], out Location loc);
          //      var userEmail = custObj[3];
          //      var isDeleted = bool.Parse(custObj[4]);
          //      var dateCreated = DateTime.Parse(custObj[5]);

          //      return new Customer(id, userId, loc, userEmail, isDeleted, dateCreated);
          // }
     }
}