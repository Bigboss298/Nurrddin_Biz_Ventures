using My_Project_Continued.Models.Enums;

namespace My_Project_Continued.Models
{
    public class Branch : BaseEntity
    {
        public Location BranchLocation;
        public string BranchHeadName;
        public string Name;

          public Branch(int id, Location branchLocation, string branchHeadName, bool isDeleted, DateTime dateCreated) : base(id, isDeleted, dateCreated)
          {
               BranchLocation = branchLocation;
               BranchHeadName = branchHeadName;
          }

          // public override string ToString()
          // {
          //      return $"{Id}\t{BranchLocation}\t{BranchHeadName}\t{IsDeleted}\t{DateCreated}";
          // }

          // public static Branch ToBranchObj(string branch)
          // {
          //      var branchObj = branch.Split('\t');
          //      var id = int.Parse(branchObj[0]);
          //      var branchLocation = Enum.TryParse(branchObj[1], out Location loc);
          //      var branchHeadName = branchObj[2];
          //      var isDeleted = bool.Parse(branchObj[3]);
          //      var dateCreated = DateTime.Parse(branchObj[4]);

          //      return new Branch(id, loc, branchHeadName, isDeleted, dateCreated);
          // }
     }
}