using My_Project_Continued.Models;
using My_Project_Continued.Models.Enums;

namespace My_Project_Continued.Managers.Interface
{
    public interface IWalletManager
    {
        Wallet Get(string walletId);
        Wallet GetBy(string locationBranch);
        List<Wallet> GetAll();
        Wallet GetName(string walletname);
    }
}
