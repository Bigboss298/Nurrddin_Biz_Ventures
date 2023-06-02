using My_Project_Continued.Managers.Interface;
using My_Project_Continued.Models;
using My_Project_Continued.Models.Enums;

namespace My_Project_Continued.Managers.Implementation
{
     public class BranchHeadManager : IBranchHeadManager
     {
          public static List<BranchHead> branchHeadsDb = new List<BranchHead>();
     //    {
     //           new BranchHead(1, Location.Lagos_State, "Abdullah Bisiriyu", "", false, DateTime.Now),
     //           new BranchHead(2, Location.Ogun_State, "Abdul Mujeeb", "", false, DateTime.Now),
     //           new BranchHead(3, Location.Osun_State, "Adesanya Mastuah", "", false, DateTime.Now),
     //           new BranchHead(4, Location.Oyo_State, "Alpha Masroor", "", false, DateTime.Now)
     //    };
          public BranchHead Get(int location)
          {
               foreach (var branchhead in branchHeadsDb)
               {
                    if (branchhead.BranchLocation == (Location)location)
                    {
                         return branchhead;
                    }
               }
               return null;
          }
          public BranchHead GetBy(string name)
          {
               foreach (var headname in branchHeadsDb)
               {
                    if (headname.Name == name)
                    {
                         return headname;
                    }
               }
               return null;
          }
          public List<BranchHead> GetAll()
          {
               if(branchHeadsDb.Count == 0)
               {
                    return null;
               }
               return branchHeadsDb;
          }

          public BranchHead GetAllMessage(string name)
          {
               foreach (var item in branchHeadsDb)
               {
                    if (item.Name == name)
                    {
                         return item;
                    }
               }
               return null;
          }
          public BranchHead Get(Location location)
          {
               foreach (var item in branchHeadsDb)
               {
                    if (item.BranchLocation == location)
                    {
                         return item;
                    }
               }
               return null;
          }
     }
}