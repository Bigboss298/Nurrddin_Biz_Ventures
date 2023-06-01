using My_Project_Continued.Models;

namespace My_Project_Continued.Managers.Interface
{
    public interface IDepositManager
    {
        Deposit Make(string walletId, double amount, int walletPin);
        Deposit Get(string walletId);
        List<Deposit> GetAll();
        Deposit GetDeposit(string depositRefNumber);
    }
}