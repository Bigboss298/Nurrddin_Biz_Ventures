using My_Project_Continued.Models.Enums;

namespace My_Project_Continued.Models
{
    public class BranchHead : BaseEntity
    {
        public Location BranchLocation;
        public string Name;
        public string Message;

          public BranchHead(int id, Location branchLocation, string name, string message, bool isDeleted, DateTime dateCreated) : base(id, isDeleted, dateCreated)
          {
               BranchLocation = branchLocation;
               Name = name;
               Message = message;
          }

     //      public override string ToString()
     //      {
     //           return $"{Id}\t{BranchLocation}\t{Name}\t{Message}\t{IsDeleted}\t{DateCreated}";
     //      }

     //      public static BranchHead ToBrachHeadobj(string branchHead)
     //      {
     //           var branchHeadObj = branchHead.Split('\t');
     //           var id = int.Parse(branchHeadObj[0]);
     //           var branchLocation = Enum.TryParse(branchHeadObj[1], out Location loc);
     //           var name = branchHeadObj[2];
     //           var message = branchHeadObj[3];
     //           var isDeleted = bool.Parse(branchHeadObj[4]);
     //           var dateCreated = DateTime.Parse(branchHeadObj[5]);

     //           return new BranchHead(id, loc, name, message, isDeleted, dateCreated);
     //      }
     }
}