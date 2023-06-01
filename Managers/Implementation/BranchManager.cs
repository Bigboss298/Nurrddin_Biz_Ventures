using My_Project_Continued.Managers.Interface;
using My_Project_Continued.Models;
using My_Project_Continued.Models.Enums;

namespace My_Project_Continued.Managers.Implementation
{
     public class BranchManager : IBranchManager
     {
        public static List<Branch> BranchDb = new List<Branch>();
     //    {
     //      new Branch(1, Location.Lagos_State, "Abdullah Bisiriyu", false, DateTime.Now),
     //      new Branch(2, Location.Ogun_State, "Abdul Mujeeb", false, DateTime.Now),
     //      new Branch(3, Location.Osun_State, "Adesanya Masturah", false, DateTime.Now),
     //      new Branch(4, Location.Oyo_State, "Alpha Masroor", false, DateTime.Now)
     //    };
          public Branch Add(Location branchLocation, string firstName, string lastName, string email, string phoneNumber, Gender gender, string password, int walletPin)
          {
               var BranchCheck = CheckBranch(branchLocation);
               if(BranchCheck)
               {
                    return null;
               }

               Branch branch = new Branch(BranchDb.Count+1, branchLocation, $"{branchLocation} Branch", false, DateTime.Now);
               BranchDb.Add(branch);

               BranchHead branchHead  = new BranchHead(BranchHeadManager.branchHeadsDb.Count+1, branchLocation, $"{firstName} {lastName}", "", false, DateTime.Now);
               BranchHeadManager.branchHeadsDb.Add(branchHead);

               User user = new User(UserManager.UserDb.Count+1, firstName, lastName, (Location)branchLocation, email, phoneNumber, "BranchHead", gender, WalletType.BranchHead, password, false, DateTime.Now);
               UserManager.UserDb.Add(user);

               Wallet wallet = new Wallet(WalletManager.WalletDb.Count+1, $"{branchLocation} Branch", GenWalletId(), 0, 0000, WalletType.BranchWallet, branchLocation, false, DateTime.Now);
               WalletManager.WalletDb.Add(wallet);

               return branch;
          }  
          public Branch Get(Location location)
          {
               foreach (var branch in BranchDb)
               {
                    if(branch.BranchLocation == (Location)location)
                    {
                        return branch;
                    }
               }
               return null;
          }
          public List<Branch> GetAll()
          {
               return BranchDb;
          }
          private bool CheckBranch(Location branchLocation)
          {
                foreach (var branch in BranchDb)
                {
                    if(branch.BranchLocation == branchLocation)
                    {
                        return true;
                    }
                }
                return false;
          }
          private string GenWalletId()
          {
                return $"WLTID/NBV/00{WalletManager.WalletDb.Count+1}";
          }
     }
}