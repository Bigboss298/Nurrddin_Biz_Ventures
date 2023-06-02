using My_Project_Continued.Managers.Implementation;
using My_Project_Continued.Managers.Interface;
using My_Project_Continued.Models.Enums;

namespace My_Project_Continued.Menu
{
     public class BranchHead
     {
          ICarManager _carManager = new CarManager();
          IBranchManager _branchManager = new BranchManager();
          IBranchHeadManager _branchHeadManager = new BranchHeadManager();
          IWalletManager _walletManager = new WalletManager();
          public void branch()
          {
               System.Console.WriteLine();
               Console.ForegroundColor = ConsoleColor.DarkCyan;
               System.Console.WriteLine("----------------------------------------------Branch Head--------------------------------------------------------");
               Console.ResetColor();
               System.Console.Write("Enter \n1 to add a Car to the store \n2 to check all your product \n3 to check cars by name \n4 to check cars by brand \n5 to view all sold Cars in your branch \n6 to view all unsold cars \n7 to check messages \n8 to Logout \nEnter : ");
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
                                        System.Console.Write("Enter your name in this format \nfirstname lastname \nEnter : ");
                                        string headname = Console.ReadLine();

                                        Console.Write("Enter the brand  : ");
                                        string brand = Console.ReadLine();

                                        System.Console.Write("Enter the name : ");
                                        string name = Console.ReadLine();

                                        System.Console.Write("Enter the model number : ");
                                        string model = Console.ReadLine();

                                        System.Console.Write("Enter the color of the car : ");
                                        string color = Console.ReadLine();

                                        System.Console.Write("Enter the price of the car : ");
                                        double price = double.Parse(Console.ReadLine());

                                        var _getloc = _branchHeadManager.GetBy(headname);
                                        var loc = _getloc.BranchLocation;

                                        System.Console.WriteLine();


                                        _carManager.Add(brand, name, color, model, price, Status.Unsold, loc);
                                        System.Console.WriteLine($"You have succesfully added {brand} {name} {model} Model to your store");
                                        branch();
                                   }
                                   break;
                              case 2:
                                   {
                                        System.Console.WriteLine("Enter your name : ");
                                        string name = Console.ReadLine();

                                        var _getloc = _branchHeadManager.GetBy(name);

                                        var car = _carManager.GetAll();
                                        if (car == null)
                                        {
                                             System.Console.WriteLine();
                                             System.Console.WriteLine("No products in your store for now!!!");
                                        }
                                        else
                                        {
                                             System.Console.WriteLine();
                                             foreach (var cars in car)
                                             {
                                                  if (cars.BranchLocation == _getloc.BranchLocation)
                                                  {
                                                       System.Console.WriteLine();
                                                       System.Console.WriteLine($"Brand : {cars.Brand} \nName : {cars.Name} \nModel : {cars.Model} \nPrice : {cars.Price:C} \nStatus : {cars.Status} \nUnique Number : {cars.UniqueNumber} \nLocation : {cars.BranchLocation} \nDate Added : {cars.DateCreated}");
                                                       System.Console.WriteLine();
                                                  }

                                             }
                                        }
                                        branch();
                                   }
                                   break;
                              case 3:
                                   {
                                        System.Console.WriteLine("Enter the name of the car : ");
                                        string name = Console.ReadLine();

                                        var carname = _carManager.GetName(name);
                                        if (carname == null)
                                        {
                                             System.Console.WriteLine();
                                             System.Console.WriteLine("Car not Found!!");
                                        }
                                        else
                                        {
                                             System.Console.WriteLine();
                                             System.Console.WriteLine("----------------------------------------------Car By Name---------------------------------------------");

                                             foreach (var cars in carname)
                                             {
                                                  System.Console.WriteLine();
                                                  System.Console.WriteLine($"Brand : {cars.Brand} \nName : {cars.Name} \nModel : {cars.Model} \nPrice : {cars.Price:C} \nStatus : {cars.Status} \nUnique Number : {cars.UniqueNumber}");

                                             }

                                        }
                                        branch();
                                   }
                                   break;
                              case 4:
                                   {
                                        System.Console.Write("Enter the brand of the car : ");
                                        string brand = Console.ReadLine();

                                        var carbrand = _carManager.Get(brand);
                                        if (carbrand == null)
                                        {
                                             System.Console.WriteLine();
                                             System.Console.WriteLine("Car not found!!!");
                                        }
                                        else
                                        {
                                             System.Console.WriteLine();
                                             System.Console.WriteLine("----------------------------------------------Car By Brand---------------------------------------------");
                                             foreach (var item in carbrand)
                                             {
                                                  System.Console.WriteLine();
                                                  System.Console.WriteLine($"Brand : {item.Brand} \nName : {item.Name} \nModel : {item.Model} \nPrice : {item.Price:C} \nStatus : {item.Status} \nUnique Number : {item.UniqueNumber}");
                                             }
                                        }
                                        branch();
                                   }
                                   break;
                              case 5:
                                   {
                                        System.Console.Write("Enter your name in this format \nFirstName LastName : ");
                                        string name = Console.ReadLine();

                                        var carBranch = _branchHeadManager.GetBy(name);

                                        var sold = _carManager.ViewSold();
                                        if (sold == null)
                                        {
                                             System.Console.WriteLine("No sales made yet!!!");

                                        }
                                        foreach (var item in sold)
                                        {
                                             if (item.BranchLocation == carBranch.BranchLocation)
                                             {
                                                  System.Console.WriteLine();
                                                  System.Console.WriteLine($"Brand : {item.Brand} \nName : {item.Name} \nModel : {item.Model} \nPrice : {item.Price:C} \nStatus : {item.Status} \nUnique Number {item.UniqueNumber}");

                                             }
                                        }
                                        branch();
                                   }
                                   break;
                              case 6:
                                   {
                                        System.Console.Write("Enter your name in this format \nFirstName LastName : ");
                                        string name = Console.ReadLine();

                                        var carBranch = _branchHeadManager.GetBy(name);

                                        var unSold = _carManager.ViewUnsold();
                                        if (unSold == null)
                                        {
                                             System.Console.WriteLine("No unsold car in the store, possibly all cars has been sold!!!");

                                        }
                                        foreach (var item in unSold)
                                        {
                                             if (item.BranchLocation == carBranch.BranchLocation)
                                             {
                                                  System.Console.WriteLine();
                                                  System.Console.WriteLine($"Brand : {item.Brand} \nName : {item.Name} \nModel : {item.Model} \nPrice : {item.Price:C} \nStatus : {item.Status} \nUnique Number {item.UniqueNumber}");
                                             }

                                        }
                                        branch();
                                   }
                                   break;
                              case 7:
                                   {
                                        System.Console.Write("ENter your name in this format \nFirstName lastName : ");
                                        string name = Console.ReadLine();

                                        var msg = _branchHeadManager.GetAllMessage(name);
                                        if (msg == null)
                                        {
                                             System.Console.WriteLine("No message here!!!");
                                        }
                                        else
                                        {
                                             System.Console.WriteLine();
                                             
                                             System.Console.WriteLine($"Message : {msg.Message}");
                                        }
                                        branch();
                                   }
                                   break;
                              case 8:
                                   {
                                        MainMenu main = new MainMenu();
                                        main.Main();
                                   }
                                   break;
                              default:
                                   {
                                        System.Console.WriteLine("Incorrect Input!!!");
                                        branch();
                                   }
                                   break;
                         }
                    }

                    catch (NullReferenceException e)
                    {
                         System.Console.WriteLine();
                         Console.ForegroundColor = ConsoleColor.DarkCyan;
                         System.Console.WriteLine(e.Message);
                         Console.ResetColor();

                         branch();
                    }
                    catch (FormatException e)
                    {
                         System.Console.WriteLine();
                         Console.ForegroundColor = ConsoleColor.DarkCyan;
                         System.Console.WriteLine(e.Message);
                         Console.ResetColor();

                         branch();
                    }

               }
               else
               {
                    System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    System.Console.WriteLine("Wrong format!!!");
                    branch();
               }


          }
     }
}
