using System.Runtime.ConstrainedExecution;
using My_Project_Continued.Managers.Implementation;
using My_Project_Continued.Managers.Interface;
using My_Project_Continued.Models.Enums;

namespace My_Project_Continued.Menu
{
     public class SuperAdminMenu
     {
          IBranchManager _branchManager = new BranchManager();
          IWalletManager _walletName = new WalletManager();
          ICarManager _carManager = new CarManager();
          IBranchHeadManager _branchHead = new BranchHeadManager();
          ICustomerManager _customer = new CustomerManager();
          IUserManager _user = new UserManager();
          public void SuperAdmin()
          {

               //int.TryParse(Console.ReadLine(), out inp);
               while (true)
               {

                    System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    System.Console.WriteLine("------------------------------------------Super Admin---------------------------------------");
                    Console.ResetColor();
                    System.Console.Write("Enter 1 to Register a Branch and assign a Branch head \n2 to view all sold car \n3 to view all unsold cars \n4 to check your wallet Balanace \n5 to view all Branch Managers \n6 to view all customers \n7 To view all cars \n8 To viell all payment made \n9 to log out : ");
                    int inp;
                    bool isValid = int.TryParse(Console.ReadLine(), out inp);
                    if (isValid && inp >= 1 && inp <= 7)
                    // if (isValid)
                    {
                         try
                         {
                              switch (inp)
                              {
                                   case 1:
                                        {
                                             System.Console.WriteLine();
                                             Console.ForegroundColor = ConsoleColor.Cyan;
                                             System.Console.WriteLine("----------------------Branch Info----------------------");
                                             Console.ResetColor();
                                             System.Console.Write("Enter the location of the branch you are about to register \n1 for Oyo State \n2 for Osun State \n3 for Lagos State \n4 for Ogun State \nEnter : ");
                                             int loc = int.Parse(Console.ReadLine());

                                             System.Console.WriteLine();
                                             Console.ForegroundColor = ConsoleColor.Cyan;
                                             System.Console.WriteLine("----------------------Branch Head Info-----------------");
                                             Console.ResetColor();

                                             System.Console.Write("Enter the First Name : ");
                                             string fname = Console.ReadLine();

                                             System.Console.Write("Enter the Last Name : ");
                                             string lname = Console.ReadLine();

                                             System.Console.Write("Enter the Email Address : ");
                                             string mail = Console.ReadLine();

                                             System.Console.Write("Enter the Phone Number : ");
                                             string phoneNumber = Console.ReadLine();

                                             System.Console.Write("Enter the Gender \n1 for Male or 2 for Female : ");
                                             int gend = int.Parse(Console.ReadLine());

                                             System.Console.Write("Enter the Password to login in : ");
                                             string password = Console.ReadLine();

                                             System.Console.Write("Enter the wallet Pin : ");
                                             int pin = int.Parse(Console.ReadLine());



                                             var reg = _branchManager.Add((Location)loc, fname, lname, mail, phoneNumber, (Gender)gend, password, pin);


                                             if (reg == null)
                                             {
                                                  System.Console.WriteLine();
                                                  Console.ForegroundColor = ConsoleColor.DarkRed;
                                                  System.Console.WriteLine("Branch Already Exist!!!");
                                                  Console.ResetColor();
                                             }
                                             else
                                             {

                                                  System.Console.WriteLine();
                                                  System.Console.WriteLine($"You have succesfully registered {(Location)loc} Branch as a new Branch in your Company");
                                                  System.Console.WriteLine($"And you have succesfully registered {fname} {lname} as your branch Manager \nand let them take note of the correct spelling of thier Names it will be asked frequently");

                                             }

                                        }
                                        break;
                                   case 2:
                                        {

                                             var sold = _carManager.ViewSold();
                                             if (sold == null)
                                             {
                                                  System.Console.WriteLine();

                                                  Console.ForegroundColor = ConsoleColor.DarkRed;
                                                  System.Console.WriteLine("No sales made yet!!!");
                                                  Console.ResetColor();

                                                  SuperAdmin();
                                             }
                                             foreach (var item in sold)
                                             {
                                                  System.Console.WriteLine();
                                                  System.Console.WriteLine($"Brand : {item.Brand} \nName : {item.Name} \nModel : {item.Model} \nPrice : {item.Price:C} \nStatus : {item.Status} \nUnique Number {item.UniqueNumber}");
                                                  SuperAdmin();
                                             }
                                        }
                                        break;
                                   case 3:
                                        {
                                             var unSold = _carManager.ViewUnsold();
                                             if (unSold == null)
                                             {
                                                  System.Console.WriteLine();
                                                  Console.ForegroundColor = ConsoleColor.DarkRed;
                                                  System.Console.WriteLine("No unsold car in the store, possibly all cars has been sold!!!");
                                                  Console.ResetColor();

                                                  SuperAdmin();
                                             }
                                             foreach (var item in unSold)
                                             {
                                                  System.Console.WriteLine();
                                                  System.Console.WriteLine($"Brand : {item.Brand} \nName : {item.Name} \nModel : {item.Model} \nPrice : {item.Price:C} \nStatus : {item.Status} \nUnique Number {item.UniqueNumber}");

                                             }
                                        }
                                        break;
                                   case 4:
                                        {
                                             System.Console.Write("Enter your wallet Id : ");
                                             string wallet = Console.ReadLine();

                                             System.Console.WriteLine();
                                             var amountCheck = _walletName.Get(wallet);

                                             System.Console.WriteLine($"Your wallet balance is : {amountCheck.WalletBalance:C}");

                                             SuperAdmin();
                                        }
                                        break;
                                   case 5:
                                        {
                                             var branchHead = _branchHead.GetAll();
                                             if (branchHead == null)
                                             {
                                                  System.Console.WriteLine();
                                                  System.Console.WriteLine("You have no Branch Manager in your branches");
                                             }
                                             else
                                             {
                                                  foreach (var item in branchHead)
                                                  {
                                                       System.Console.WriteLine();
                                                       System.Console.WriteLine($"Name : {item.Name} \nLocation : {item.BranchLocation} \nDate Assigned : {item.DateCreated}");
                                                  }
                                             }
                                             SuperAdmin();
                                        }
                                        break;
                                   case 6:
                                        {

                                             var user = _user.GetAll();
                                             if (user == null)
                                             {
                                                  System.Console.WriteLine();
                                                  System.Console.WriteLine("No customer account yet!!!");
                                             }
                                             else
                                             {
                                                  foreach (var cust in user)
                                                  {
                                                       if (cust.Role.ToUpper() == "CUSTOMER")
                                                       {
                                                            System.Console.WriteLine();
                                                            System.Console.WriteLine("------------------------------------------------Customers-----------------------------------------------------");
                                                            System.Console.WriteLine($"Name : {cust.FirstName} {cust.LastName} \nLocation : {cust.Location} \nEmail Address : {cust.Email} \nPhone Number : {cust.PhoneNumber} \nGender : {cust.Gender}");
                                                       }
                                                  }
                                             }
                                             SuperAdmin();
                                        }
                                        break;
                                   case 7:
                                        {
                                             var cars = _carManager.GetAll();
                                             if (cars == null)
                                             {
                                                  System.Console.WriteLine();
                                                  System.Console.WriteLine("No car in your stores yet!!!");
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
                                             SuperAdmin();

                                        }
                                        break;
                                   case 8:
                                        {
                                             IPaymentManager _payment = new PaymentManager();
                                             var pays = _payment.GetAll();
                                             if (pays == null)
                                             {
                                                  System.Console.WriteLine();
                                                  System.Console.WriteLine("No Payment Made yet!!!");
                                             }
                                             else
                                             {
                                                  foreach (var pay in pays)
                                                  {
                                                       System.Console.WriteLine();
                                                       System.Console.WriteLine($"Customer Wallet Id : {pay.BenefactorWalletId} \nAmount Paid : {pay.Amount} \nReference Number : {pay.PaymentRefNumber} \nDate Paid : {pay.DateCreated}");
                                                  }
                                             }
                                             SuperAdmin();
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
                                             System.Console.WriteLine("incorrect inputs");
                                             SuperAdmin();
                                        }
                                        break;
                              }
                         }

                         catch (NullReferenceException)
                         {
                              System.Console.WriteLine();
                              Console.ForegroundColor = ConsoleColor.DarkCyan;
                              System.Console.WriteLine("Kindly check your inputs and try again!!!, it doesn't exit");
                              Console.ResetColor();
                              SuperAdmin();

                         }
                         catch (FormatException)
                         {
                              System.Console.WriteLine();
                              Console.ForegroundColor = ConsoleColor.DarkCyan;
                              System.Console.WriteLine("your input box is either empty or your are inputting the wrong format!!!");
                              Console.ResetColor();
                              SuperAdmin();
                         }
                    }
                    else
                    {
                         System.Console.WriteLine();
                         System.Console.WriteLine("Incorrect Format!!!");
                         SuperAdmin();
                    }

               }


          }
     }
}

