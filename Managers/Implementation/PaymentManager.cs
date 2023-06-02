using My_Project_Continued.Managers.Interface;
using My_Project_Continued.Models;

namespace My_Project_Continued.Managers.Implementation
{
     public class PaymentManager : IPaymentManager
     {
          IWalletManager walletManager = new WalletManager();
          ICarManager carManager = new CarManager();
          IBranchHeadManager _branchHead = new BranchHeadManager();
          public static List<Payment> PaymentDb = new List<Payment>();
          public Payment Get(string paymentRefNumber)
          {
               foreach (var payment in PaymentDb)
               {
                    if (payment.PaymentRefNumber == paymentRefNumber)
                    {
                         return payment;
                    }
               }
               return null;
          }

          public List<Payment> GetAll()
          {
               if(PaymentDb.Count <= 1)
               {
                    return null;
               }
               return PaymentDb;
          }

          public (Payment, string, int) Make(string benefactorWalletId, string beneficiaryWalletId, int pin, double amount, string uniqueNumber)
          {
               var payer = walletManager.Get(benefactorWalletId);
               var reciever = walletManager.Get(beneficiaryWalletId);
               var price = carManager.GetBy(uniqueNumber);
               var msg = _branchHead.Get(reciever.Location);


               

               if (payer == null || reciever == null)
               {
                    return (null, "Customer Wallet Id not correct", 0);
               }
               else
               {
                    if (payer.WalletPin == pin)
                    {
                         if (price.Status == Models.Enums.Status.Unsold)
                         {
                              if (price.BranchLocation == payer.Location)
                              {
                                   payer.WalletBalance -= amount;
                                   reciever.WalletBalance += amount;
                                   // var message = ;
                                   msg.Message += $"{payer.WalletName} just a made purchase of \nCar Brand : {price.Model} \nCar Name : {price.Name} \nPrice of Car : {price.Price:C} \nUnique Number : {price.UniqueNumber}\n";
                                   
                                   Payment payment = new Payment(PaymentDb.Count + 1, beneficiaryWalletId, benefactorWalletId, pin, amount, GenPayRefNum(), false, DateTime.Now);
                                   PaymentDb.Add(payment);
                                   return (payment, "Transaction Succesfull", 0);
                              }
                              else
                              {

                                   payer.WalletBalance -= (amount + 2000);
                                   reciever.WalletBalance += (amount + 2000);
                                   msg.Message += $"{payer.WalletName} a customer from your location just  made a purchase of \nCar Brand : {price.Brand} \nCar Name : {price.Name} \nCar Model : {price.Model}\nPrice of Car : {price.Price:C} \nUnique Number : {price.UniqueNumber} \nColor : {price.Color} in another branch";



                                   Payment payment = new Payment(PaymentDb.Count + 1, beneficiaryWalletId, benefactorWalletId, pin, amount, GenPayRefNum(), false, DateTime.Now);
                                   PaymentDb.Add(payment);
                                   return (payment, "Transaction Succesfull", 2000);

                              }
                         }
                         else
                         {

                              return (null, "Car already sold!!!", 0);
                         }
                    }
                    else
                    {

                         return (null, "Incorrect pin!!!", 0);
                    }
               }
          }
          private string GenPayRefNum()
          {
               var rand = new Random();
               return "PYM/NBV/" + rand.Next(001, 100).ToString();
          }
     }
}