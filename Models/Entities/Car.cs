using My_Project_Continued.Models.Enums;

namespace My_Project_Continued.Models
{
    public class Car : BaseEntity
    {
        public string Brand;
        public string Name;
        public string Color;
        public string Model;
        public string UniqueNumber;
        public double Price;
        public Status Status;
        public Location BranchLocation;

          public Car(int id, string brand, string name, string color, string model, string uniqueNumber, double price, Status status, Location branchLocation, bool isDeleted, DateTime dateCreated) : base(id, isDeleted, dateCreated)
          {
               Brand = brand;
               Name = name;
               Color = color;
               Model = model;
               UniqueNumber = uniqueNumber;
               Price = price;
               Status = status;
               BranchLocation = branchLocation;
          }

          // public override string ToString()
          // {
          //      return $"{Id}\t{Brand}\t{Name}\t{Color}\t{Model}\t{UniqueNumber}\t{Price}\t{Status}\t{BranchLocation}\t{IsDeleted}\t{DateCreated}";
          // }

          // public static Car ToCarObj(string car)
          // {
          //      var carObj = car.Split('\t');
          //      var id = int.Parse(carObj[0]);
          //      var brand = carObj[1];
          //      var name = carObj[2];
          //      var color = carObj[3];
          //      var model = carObj[4];
          //      var uniqueNumber = carObj[5];
          //      var price = double.Parse(carObj[6]);
          //      var status = Enum.TryParse(carObj[7], out Status stat);
          //      var branchLocation = Enum.TryParse(carObj[8], out Location loc);
          //      var isDeleted = bool.Parse(carObj[9]);
          //      var dateCreated = DateTime.Parse(carObj[10]);

          //      return new Car(id, brand, name, color, model, uniqueNumber, price, stat, loc, isDeleted, dateCreated);
          // }
     }
}