using My_Project_Continued.Managers.Implementation;
using My_Project_Continued.Managers.Interface;
using My_Project_Continued.Models.Enums;

namespace My_Project_Continued.Menu
{
     public class MainMenu
     {
          IBranchManager _branchManager = new BranchManager();
          IUserManager _userManager = new UserManager();
          ICustomerManager _customerManager = new CustomerManager();
          IWalletManager _walletManager = new WalletManager();
          public void Main()
          {
               System.Console.WriteLine();
               Console.ForegroundColor = ConsoleColor.Cyan;
               System.Console.WriteLine("------------------------------------WELCOME TO NURRDIN BIZ VENTURES-----------------------------------------");
               Console.ResetColor();
               System.Console.Write("Enter 1 to register as a customer or 2 to log in : ");
               int opt;
               bool isValid = int.TryParse(Console.ReadLine(), out opt);
               if (isValid)
               {
                    switch (opt)
                    {
                         case 1:
                              {
                                   Register();
                                   Main();
                              }
                              break;
                         case 2:
                              {
                                   Login();
                                   Main();
                              }
                              break;
                         default:
                              {
                                   System.Console.WriteLine();
                                   Console.ForegroundColor = ConsoleColor.DarkRed;
                                   System.Console.WriteLine("Wrong input!!!");
                                   Console.ResetColor();
                                   Main();
                              }
                              break;
                    }
               }
               else
               {
                    System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine("Incorrect Format!!!");
                    Console.ResetColor();
                    Main();
               }



          }
          public void Login()

          {
               Console.ForegroundColor = ConsoleColor.Cyan;
               System.Console.WriteLine("---------------------------------------------LOGIN-----------------------------------------------");
               Console.ResetColor();

               System.Console.Write("Enter your Email Address : ");
               string email = Console.ReadLine();

               System.Console.Write("Enter your password : ");
               string password = Console.ReadLine();

               var login = _userManager.Login(email, password);
               if (login == null)
               {
                    System.Console.WriteLine("Check your password or email and try again!!!");
                    Login();
               }
               else
               {
                    if (login.Role == "SuperAdmin")
                    {
                         SuperAdminMenu _super = new SuperAdminMenu();
                         _super.SuperAdmin();
                    }
                    else if (login.Role == "BranchHead")
                    {
                         BranchHead _branchHead = new BranchHead();
                         _branchHead.branch();
                    }
                    else if (login.Role == "Customer")
                    {
                         CustomerMenu _customer = new CustomerMenu();
                         _customer.Customer();
                    }
               }
          }

          public void Register()
          {
               try
               {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    System.Console.WriteLine("----------------------------------------------------Register----------------------------------------------------");
                    Console.ResetColor();

                    System.Console.Write("Enter your first name : ");
                    string first = Console.ReadLine();

                    System.Console.Write("Enter your last name : ");
                    string last = Console.ReadLine();

                    System.Console.Write("Enter your location \nEnter 1 for Oyo State, 2 for Osun State, 3 for Lagos state and 4 for Ogun state :  ");
                    int loc = int.Parse(Console.ReadLine());

                    System.Console.Write("Enter your email address : ");
                    string mail = Console.ReadLine();

                    System.Console.Write("Enter your phone number : ");
                    string phone = Console.ReadLine();

                    System.Console.Write("Enter your gender \n1 for Male or 2 for female : ");
                    int gend = int.Parse(Console.ReadLine());

                    System.Console.Write("Enter you account password : ");
                    string password = Console.ReadLine();

                    System.Console.Write("Enter your wallet pin : ");
                    int pin = int.Parse(Console.ReadLine());

                    var reg = _customerManager.Open(first, last, (Location)loc, mail, phone, (Gender)gend, pin, password);


                    if (reg == null)
                    {
                         System.Console.WriteLine();
                         Console.ForegroundColor = ConsoleColor.DarkRed;
                         System.Console.WriteLine("User already Exists!!!");
                         Console.ResetColor();
                    }
                    else
                    {

                         System.Console.WriteLine();
                         Console.ForegroundColor = ConsoleColor.Cyan;
                         var gends = gend == 1 ? "Mr" : "Mrs";
                         System.Console.WriteLine($"{gends} {first} {last} you have succesfully registered as a user");
                         System.Console.WriteLine($"Your wallet Id is : {_walletManager.GetName($"{first} {last}").WalletId}");
                         Console.ResetColor();

                         System.Console.WriteLine();
                         Main();
                    }
               }
               catch (NullReferenceException e)
               {
                    System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine(e.Message);
                    Console.ResetColor();

                    System.Console.WriteLine();
                    Register();
               }
               catch (FormatException e)
               {
                     System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine(e.Message);
                    Console.ResetColor();

                    System.Console.WriteLine();
                    Register();
               }
          }
     }
}