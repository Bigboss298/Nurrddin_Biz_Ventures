using My_Project_Continued.Models;

namespace My_Project_Continued.Managers.Interface
{
    public interface IPaymentManager
    {
        (Payment, string, int) Make(string benefactorWalletId, string beneficiaryWalletId, int pin, double amount, string uniqueNumber);
        Payment Get(string paymentRefNumber);
        List<Payment> GetAll();
        
    }
}