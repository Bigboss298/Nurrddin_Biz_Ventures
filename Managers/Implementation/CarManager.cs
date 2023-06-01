using My_Project_Continued.Managers.Interface;
using My_Project_Continued.Models;
using My_Project_Continued.Models.Enums;

namespace My_Project_Continued.Managers.Implementation
{
     public class CarManager : ICarManager
     {
          public static List<Car> CarDb = new List<Car>();
          // {
          //      new Car(12, "Toyota", "Camry", "Black", "2012", "UIN/N0/001", 50000, Status.Unsold, Location.Osun_State, false, DateTime.Now),
          //      new Car(10, "Toyota", "Camry", "Blue", "2011", "UIN/N0/002", 40000, Status.Sold, Location.Lagos_State, false, DateTime.Now)
          // };
          public Car Add(string brand, string name, string color, string model, double price, Status status, Location location)
          {
               Car car = new Car(CarDb.Count + 1, brand, name, color, model, GenUniqueNum(), price, Status.Unsold, location, false, DateTime.Now);
               CarDb.Add(car);

               return car;
          }
          public List<Car> Get(string brand)
          {
               List<Car> filteredBrands = new List<Car>();
               foreach (var car in CarDb)
               {
                    if (car.Brand == brand)
                    {
                         filteredBrands.Add(car);
                    }
               }
               if (filteredBrands.Count == 0)
               {
                    return null;
               }
               return filteredBrands;
          }
          public List<Car> GetName(string name)
          {
               List<Car> filteredCars = new List<Car>();
               foreach (var car in CarDb)
               {
                    if (car.Name == name)
                    {
                         filteredCars.Add(car);
                    }
               }
               if (filteredCars.Count == 0)
               {
                    return null;
               }
               return filteredCars;
          }

          public List<Car> GetAll()
          {
               return CarDb;
          }

          // public List<Car> GetAll(int location)
          // {
          //      List<Car> branchCars = new List<Car>();
          //      foreach (var car in CarDb)
          //      {
          //           if(car.BranchLocation == l)
          //           {
          //                branchCars.Add(car);
          //           }
          //      }
          //      if (branchCars.Count < 0)
          //      {
          //           return null;
          //      }
          //      return branchCars;
          // }

          public Car GetBy(string uniqueNumber)
          {
               foreach (var car in CarDb)
               {
                    if (car.UniqueNumber == uniqueNumber)
                    {
                         return car;
                    }
               }
               return null;
          }
          public string GenUniqueNum()
          {
               return $"UIN/N0/00{CarDb.Count + 1}";
          }

          public List<Car> ViewSold()
          {
               List<Car> soldCars = new List<Car>();
               foreach (var car in CarDb)
               {
                    if (car.Status == Status.Sold)
                    {
                         soldCars.Add(car);
                    }
               }
               if (soldCars.Count == 0)
               {
                    return null;
               }
               return soldCars;
          }

          public List<Car> ViewUnsold()
          {
               List<Car> unSoldCars = new List<Car>();
               foreach (var car in CarDb)
               {
                    if (car.Status == Status.Unsold)
                    {
                         unSoldCars.Add(car);
                    }
               }
               if (unSoldCars.Count == 0)
               {
                    return null;
               }
               return unSoldCars;
          }

          public List<Car> View(Location location)
          {
               List<Car> branchCars = new List<Car>();
               foreach (var car in CarDb)
               {
                    if(car.BranchLocation == location)
                    {
                         branchCars.Add(car);
                    }
               }
               if (branchCars.Count < 0)
               {
                    return null;
               }
               return branchCars;
          }
     }
}

