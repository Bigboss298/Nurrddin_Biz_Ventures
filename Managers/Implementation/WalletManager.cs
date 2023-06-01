using My_Project_Continued.Managers.Interface;
using My_Project_Continued.Models;
using My_Project_Continued.Models.Enums;

namespace My_Project_Continued.Managers.Implementation
{
     public class WalletManager : IWalletManager
     {
        public static List<Wallet> WalletDb = new List<Wallet>()
        {
            new Wallet(1, "Big boss", "WALTID/NBV/001", 0, 1234, WalletType.SuperAdmin, Location.Oyo_State, false, DateTime.Now),
     //        new Wallet(2, "Anuoluwa Olawale", "WALTID/NBV/002", 3000000, 3456, WalletType.Customer, Location.Oyo_State, false, DateTime.Now),
     //        new Wallet(3, $"{Location.Lagos_State} Branch", "WALTID/NBV/003", 0, 5678, WalletType.BranchWallet, Location.Lagos_State, false, DateTime.Now),
     //        new Wallet(4, $"{Location.Ogun_State} Branch", "WALTID/NBV/004", 0, 6789, WalletType.BranchWallet, Location.Ogun_State, false, DateTime.Now),
     //        new Wallet(5, $"{Location.Osun_State} Branch", "WALTID/NBV/005", 0, 7890, WalletType.BranchWallet, Location.Osun_State, false, DateTime.Now),
     //        new Wallet(6, $"{Location.Oyo_State} Branch", "WALTID/NBV/006", 0, 8900, WalletType.BranchWallet, Location.Oyo_State, false, DateTime.Now),
     //        new Wallet(7, "Abdul Mujeeb", "WALTID/NBV/007", 0, 7777, WalletType.BranchHead, Location.Ogun_State, false, DateTime.Now),
     //        new Wallet(8, "Adesanya Masturah", "WALTID/NBV/008", 0, 8888, WalletType.BranchHead, Location.Osun_State, false, DateTime.Now),
     //        new Wallet(9, "Alpha Masroor", "WALTID/NBV/009", 0, 9999, WalletType.BranchHead, Location.Oyo_State, false, DateTime.Now),
     //        new Wallet(10, "Abdullah Bisiriyu", "WALTID/NBV/010", 0, 1010, WalletType.BranchHead, Location.Lagos_State, false, DateTime.Now)
        };
          public Wallet Get(string walletId)
          {
               foreach (var wallet in WalletDb)
               {
                    if(wallet.WalletId == walletId)
                    {
                        return wallet;
                    }
               }
               return null;
          }
          public Wallet GetBy(string locationBranch)
          {
               foreach (var wallet in WalletDb)
               {
                    if(wallet.LocationBranch == locationBranch)
                    {
                         return wallet;
                    }
               }
               return null;
          }

          public List<Wallet> GetAll()
          {
              return WalletDb;
          }

          public Wallet GetName(string walletname)
          {
               foreach (var item in WalletDb)
               {
                   if(item.WalletName == walletname)
                   {
                          return item;
                   }
               }
               return null;
          }
     }
}
