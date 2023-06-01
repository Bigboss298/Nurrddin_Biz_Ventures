using My_Project_Continued.Models;
using My_Project_Continued.Models.Enums;

namespace My_Project_Continued.Managers.Interface
{
    public interface IBranchHeadManager
    {
        BranchHead Get(Location location);
        List<BranchHead> GetAll();
        BranchHead GetBy(string name);
        BranchHead GetAllMessage(string name); 
    }
}