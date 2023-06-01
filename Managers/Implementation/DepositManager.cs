using My_Project_Continued.Managers.Interface;
using My_Project_Continued.Models;

namespace My_Project_Continued.Managers.Implementation
{
     public class DepositManager : IDepositManager
     {
        IWalletManager walletManager = new WalletManager();
        public static List<Deposit> DepositDb = new List<Deposit>();
     //    {
     //      new Deposit(1, "WALTID/NBV/002", 30000, 3456, "DPT/NBV/101",false, DateTime.Now)
     //    };
          public Deposit Get(string walletId)
          {
               foreach (var deposit in DepositDb)
               {
                    if(deposit.WalletId == walletId)
                    {
                        return deposit;
                    }
               }
               return null;
          }

          public List<Deposit> GetAll()
          {
               return DepositDb;
          }

          public Deposit Make(string walletId, double amount, int walletPin)
          {
               var id = walletManager.Get(walletId);
               if(id == null)
               {
                    return null;
               }
               else 
               {
                    if(id.WalletPin == walletPin)
                    {
                        if(amount > 0)
                        {
                            id.WalletBalance += amount;

                            Deposit deposit = new Deposit(DepositDb.Count+1, walletId, amount, walletPin, GenDepoRefNum(), false, DateTime.Now);
                            DepositDb.Add(deposit);

                            return deposit;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
               }
          }

          private string GenDepoRefNum()
          {
                var rand = new Random();
                return "DPT/NBV/" + rand.Next(100, 200).ToString();
          }

          public Deposit GetDeposit(string depositRefNumber)
          {
               foreach (var item in DepositDb)
               {
                    if(item.DepositRefNumber == depositRefNumber)
                    {
                         return item;
                    }
               }
               return null;
          }
     }
}