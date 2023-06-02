using My_Project_Continued.Models;
using My_Project_Continued.Models.Enums;

namespace My_Project_Continued.Managers.Interface
{
    public interface ICarManager
    {
        Car Add(string brand, string name, string color, string model, double price, Status status, Location location);
        List<Car> Get(string brand);
        List<Car> GetName(string name);
        Car GetBy(string uniqueNumber);
        List<Car> GetAll();
     //    List<Car> GetAll(int location);
        List<Car> ViewSold();
        List<Car> ViewUnsold();
        List<Car> View(Location location);

    }
}