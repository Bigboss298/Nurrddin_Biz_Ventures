using System.Runtime.ConstrainedExecution;
using My_Project_Continued.Managers.Implementation;
using My_Project_Continued.Managers.Interface;
using My_Project_Continued.Models.Enums;

namespace My_Project_Continued.Menu
{
     public class CustomerMenu
     {
          ICarManager _carManager = new CarManager();
          IDepositManager _depositManager = new DepositManager();
          IWalletManager _walletManager = new WalletManager();
          IPaymentManager _paymentManager = new PaymentManager();
          IBranchManager _branchManager = new BranchManager();

          public void Customer()
          {
               System.Console.WriteLine();
               Console.ForegroundColor = ConsoleColor.Cyan;
               System.Console.WriteLine("---------------------------------------------Customer Menu--------------------------------------------------------");
               Console.ResetColor();

               System.Console.Write("Enter 1 view all cars by thier brand Name \nEnter 2 to view all cars by thier name \nEnter 3 to add money to your wallet \nEnter 4 to check your Wallet Balance \nEnter 5 to purchase a car \nEnter 6 to track deposits with thier reference Number \nEnter 7 to check all  cars available \n8 To view all your deposit \n9 To logout \nEnter here : ");
               // int opt = int.Parse(Console.ReadLine());
               int opt;
               bool isValid = int.TryParse(Console.ReadLine(), out opt);
               if (isValid)
               {
                    try
                    {
                         switch (opt)
                         {
                              case 1:
                                   {
                                        System.Console.Write("Enter the brand of the car : ");
                                        string brand = Console.ReadLine();

                                        var carbrand = _carManager.Get(brand);
                                        if (carbrand == null)
                                        {
                                             System.Console.WriteLine();
                                             Console.ForegroundColor = ConsoleColor.Cyan;
                                             System.Console.WriteLine("-----------------------------------------------------Cars By Brand-------------------------------------------------------------");
                                             Console.ResetColor();
                                             System.Console.WriteLine();
                                             System.Console.WriteLine("Car not found!!!");
                                        }
                                        else
                                        {
                                             System.Console.WriteLine();
                                             Console.ForegroundColor = ConsoleColor.Cyan;
                                             System.Console.WriteLine("-----------------------------------------------------Cars By Brand-------------------------------------------------------------");
                                             Console.ResetColor();
                                             foreach (var item in carbrand)
                                             {
                                                  System.Console.WriteLine();
                                                  System.Console.WriteLine($"Brand : {item.Brand} \nName : {item.Name} \nModel : {item.Model} \nPrice  : {item.Price:C} \nBranch : {item.BranchLocation} \nStatus : {item.Status} \nUnique Number : {item.UniqueNumber}");
                                             }
                                        }
                                        Customer();
                                   }
                                   break;
                              case 2:
                                   {
                                        System.Console.Write("Enter the name of the car : ");
                                        string name = Console.ReadLine();

                                        var carsName = _carManager.GetName(name);
                                        if (carsName == null)
                                        {
                                             System.Console.WriteLine();
                                             Console.ForegroundColor = ConsoleColor.Cyan;
                                             System.Console.WriteLine("-----------------------------------------------------Cars By Name-------------------------------------------------------------");
                                             Console.ResetColor();
                                             System.Console.WriteLine();
                                             System.Console.WriteLine("Car not Found!!");
                                        }
                                        else
                                        {
                                             System.Console.WriteLine();
                                             Console.ForegroundColor = ConsoleColor.Cyan;
                                             System.Console.WriteLine("-------------------------------------------------------------Cars By Name-------------------------------------------------------");
                                             Console.ResetColor();
                                             foreach (var car in carsName)
                                             {
                                                  System.Console.WriteLine();
                                                  System.Console.WriteLine($"Brand : {car.Brand} \nName : {car.Name} \nModel : {car.Model} \nBranch : {car.BranchLocation} \nPrice : {car.Price:C} \nStatus : {car.Status} \nUnique Number {car.UniqueNumber} ");
                                             }
                                        }
                                        Customer();
                                   }
                                   break;
                              case 3:
                                   {
                                        DepositForm();
                                        Customer();
                                   }
                                   break;
                              case 4:
                                   {
                                        System.Console.Write("Enter your wallet Id : ");
                                        string wallet = Console.ReadLine();

                                        System.Console.WriteLine();
                                        var amountCheck = _walletManager.Get(wallet);
                                        System.Console.WriteLine($"Your wallet balance is : {amountCheck.WalletBalance:C}");
                                        Customer();
                                   }
                                   break;
                              case 5:
                                   {
                                        PaymentForm();
                                        Customer();
                                   }
                                   break;
                              case 6:
                                   {
                                        System.Console.Write("Enter the reference number of the deposit you want to track : ");
                                        string depo = Console.ReadLine();

                                        var deposit = _depositManager.GetDeposit(depo);
                                        if(deposit == null)
                                        {
                                             System.Console.WriteLine("No such deposit has been made!!!");
                                        }
                                        else 
                                        {
                                             System.Console.WriteLine();
                                             System.Console.WriteLine($"Depositor Id : {deposit.WalletId} \nAmount : {deposit.Amount:C} \nDate Deposited : {deposit.DateCreated} \nReference Number : {deposit.DepositRefNumber}");
                                        }
                                        Customer();
                                   }
                                   break;
                              case 7: 
                                   {
                                        var cars = _carManager.GetAll();
                                        if (cars == null)
                                        {
                                             System.Console.WriteLine();
                                             System.Console.WriteLine("No car in the store");
                                        }
                                        else 
                                        {
                                             System.Console.WriteLine();
                                             System.Console.WriteLine("----------------------------------------------------LIST OF CARS-----------------------------------------");
                                             foreach (var car in cars)
                                             {
                                                  System.Console.WriteLine();
                                                  System.Console.WriteLine($"Brand : {car.Brand} \nName : {car.Name} \nColor : {car.Color} \nStatus : {car.Status} \nModel : {car.Model} \nLocation : {car.BranchLocation} \nUIN : {car.UniqueNumber}");
                                             }
                                        }
                                   }
                                   break;
                              case 8:
                                   {
                                        System.Console.Write("Enter your wallet Id : ");
                                        var id = Console.ReadLine();

                                        var depos = _depositManager.GetAll();
                                        if(depos == null)
                                        {
                                             System.Console.WriteLine();
                                             System.Console.WriteLine("You havent't added money to your wallet so far!!!");
                                        }
                                        else 
                                        {
                                             foreach (var depo in depos)
                                             {
                                                  if(depo.WalletId == id)
                                                  {
                                                       System.Console.WriteLine();
                                                       System.Console.WriteLine($"Amount : {depo.Amount} \nWallet Id : {depo.WalletId} \nRefernce Number : {depo.DepositRefNumber} \nDate Deposited : {depo.DateCreated}");
                                                  }
                                             }
                                        }
                                   }
                                   break;
                              case 9:
                                   {
                                        MainMenu main = new MainMenu();
                                        main.Main();
                                   }
                                   break;
                              default:
                                   {
                                        System.Console.WriteLine();
                                        System.Console.WriteLine("Incorrect inputs enter from 1 - 6");
                                        Customer();
                                   }
                                   break;

                         }
                    }
                    catch (NullReferenceException e)
                    {
                         Console.ForegroundColor = ConsoleColor.Cyan;
                         System.Console.WriteLine(e.Message);
                         Console.ResetColor();
                         Customer();
                    }

               }
               else
               {
                    System.Console.WriteLine();
                    System.Console.WriteLine("Wrong format!!!");
                    Customer();
               }

               void DepositForm()
               {
                    System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    System.Console.WriteLine("---------------------------------------------------Deposit Form-----------------------------------------------------");
                    Console.ResetColor();

                    System.Console.Write("Enter your wallet Id : ");
                    string waltId = Console.ReadLine();

                    System.Console.Write("Enter the amout you want to add : ");
                    double amountToAdd = double.Parse(Console.ReadLine());

                    System.Console.Write("Enter your wallet pin :");
                    int pin = int.Parse(Console.ReadLine());

                    var depositCheck = _depositManager.Make(waltId, amountToAdd, pin);


                    if (depositCheck == null)
                    {
                         System.Console.WriteLine();
                         System.Console.WriteLine("Deposit Failed!!!");
                    }
                    else
                    {
                         System.Console.WriteLine();
                         System.Console.WriteLine($"Transaction succesfull!! \nYour transaction reference number is {depositCheck.DepositRefNumber}");
                         System.Console.WriteLine("-----------------------------------------------------------------------------------------------");

                    }

               }

               void PaymentForm()
               {
                    System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    System.Console.WriteLine("----------------------------------------------------------Payment Form-------------------------------------------------------------");
                    Console.ResetColor();

                    try
                    {

                         System.Console.Write("Enter your wallet Id : ");
                         string benefactor = Console.ReadLine();

                         System.Console.Write("Enter the car Unique Number : ");
                         var uin = Console.ReadLine();

                         var carPrize = _carManager.GetBy(uin);
                         var amt = carPrize.Price;
                        
                         System.Console.WriteLine();
                         Console.ForegroundColor = ConsoleColor.Cyan;
                          System.Console.WriteLine("The price of the car is {0:C}", amt); 
                         Console.ResetColor();

                         System.Console.WriteLine("Do you want to continue to checkout? : ");
                         System.Console.Write("Enter \"Yes\" or \"No\" : ");

                         string ans = Console.ReadLine();

                         if (ans.ToUpper() == "YES")
                         {
                              if (_walletManager.Get(benefactor).Location != carPrize.BranchLocation)
                              {
                                   System.Console.WriteLine();
                                   Console.ForegroundColor = ConsoleColor.DarkCyan;
                                   System.Console.WriteLine($"This car isn't in your location it is in another location, \nbut can be shipped in which will include extra {2000:C} for shipping \nand extra two days for delivery");
                                   Console.ResetColor();
                                   System.Console.WriteLine();
                                   System.Console.Write("Enter 1 to proceed or 2 to stop : ");
                                   int opt;
                                   bool isValid = int.TryParse(Console.ReadLine(), out opt);
                                   if (isValid)
                                   {
                                        if (opt == 1)
                                        {
                                             System.Console.Write("Enter your pin : ");
                                             int pin = int.Parse(Console.ReadLine());

                                             var (payment, message, deliveryFee) = _paymentManager.Make(benefactor, "WALTID/NBV/001", pin, amt, uin);
                                             if (payment == null)
                                             {
                                                  System.Console.WriteLine();
                                                  Console.ForegroundColor = ConsoleColor.Cyan;
                                                  System.Console.WriteLine(message);
                                                  Console.ResetColor();
                                             }
                                             else
                                             {
                                                  System.Console.WriteLine();
                                                  Console.ForegroundColor = ConsoleColor.Cyan;
                                                  System.Console.WriteLine(message);
                                                  Console.ResetColor();

                                                  System.Console.WriteLine("--------------------------------------Reciept-----------------------------------------------");
                                                  System.Console.WriteLine($"Date : {DateTime.Now} \nUnique Number : {uin} \nBrand : {carPrize.Brand} \nName : {carPrize.Name} \nModel : {carPrize.Model} \nColor : {carPrize.Color} \nBranch : {carPrize.BranchLocation} \nPrize of Car : {carPrize.Price:C}" + "\nAmout paid : {0:C}", amt + deliveryFee);
                                                  System.Console.WriteLine($"Payment Reference Number : {payment.PaymentRefNumber}");
                                                  carPrize.Status = Status.Sold;
                                             }
                                        }
                                        else
                                        {
                                             System.Console.WriteLine();
                                             Customer();
                                        }
                                   }
                                   else
                                   {
                                        System.Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        System.Console.WriteLine("Wrong format!!!");
                                        System.Console.WriteLine();
                                        Console.ResetColor();
                                        PaymentForm();
                                   }
                              }
                              else
                              {
                                   System.Console.WriteLine("Enter your pin : ");
                                   int pin = int.Parse(Console.ReadLine());

                                   var (payment, message, deliveryFee) = _paymentManager.Make(benefactor, "WALTID/NBV/001", pin, amt, uin);
                                   if (payment == null)
                                   {
                                        System.Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        System.Console.WriteLine(message);
                                        Console.ResetColor();
                                   }
                                   else
                                   {
                                        System.Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        System.Console.WriteLine(message);
                                        Console.ResetColor();

                                        System.Console.WriteLine("--------------------------------------Reciept-----------------------------------------------");
                                        System.Console.WriteLine($"Date : {DateTime.Now} \nUnique Number : {uin} \nBrand : {carPrize.Brand} \nName : {carPrize.Name} \nModel : {carPrize.Model} \nColor : {carPrize.Color} \nBranch : {carPrize.BranchLocation} \nPrize of Car : {carPrize.Price:C}" + "\nAmout paid : {0:C}", amt + deliveryFee);
                                        System.Console.WriteLine($"Payment Reference Number : {payment.PaymentRefNumber}");
                                        carPrize.Status = Status.Sold;
                                   }
                              }
                         }
                         else if (ans.ToUpper() == "NO")
                         {
                              System.Console.WriteLine();
                              Console.ForegroundColor = ConsoleColor.Cyan;
                              System.Console.WriteLine("Thank you!!!");
                              Console.ResetColor();

                              Customer();
                         }
                         else
                         {
                              Console.ForegroundColor = ConsoleColor.DarkRed;
                              System.Console.WriteLine("Incorrect Input!!!");
                              Console.ResetColor();

                              Customer();
                         }
                    }
                    catch (NullReferenceException)
                    {
                         System.Console.WriteLine();
                         Console.ForegroundColor = ConsoleColor.Cyan;
                         System.Console.WriteLine("Kindly check your inputs and try again!!!, it doesn't exit");
                         Console.ResetColor();

                         Customer();
                    }
                    catch (FormatException)
                    {
                         System.Console.WriteLine();
                         Console.ForegroundColor = ConsoleColor.Cyan;
                         System.Console.WriteLine("your input box is either empty or your are inputting the wrong format!!!");
                         Console.ResetColor();

                         Customer();
                    }
               }
          }
     }
}






