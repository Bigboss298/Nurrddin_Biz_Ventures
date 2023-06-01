namespace My_Project_Continued.Models
{
    public class Payment : BaseEntity
    {
        public string BeneficiaryWalletId;
        public string BenefactorWalletId;
        public int Pin;
        public double Amount;
        public string PaymentRefNumber;

          public Payment(int id, string beneficiaryWalletId, string benefactorWalletId, int pin, double amount, string paymentRefNumber, bool isDeleted, DateTime dateCreated) : base(id, isDeleted, dateCreated)
          {
               BeneficiaryWalletId = beneficiaryWalletId;
               BenefactorWalletId = benefactorWalletId;
               Pin = pin;
               Amount = amount;
               PaymentRefNumber = paymentRefNumber;
          }

          // public override string ToString()
          // {  
          //      return $"{Id}\t{BeneficiaryWalletId}\t{BenefactorWalletId}\t{Pin}\t{Amount}\t{PaymentRefNumber}\t{IsDeleted}\t{DateCreated}";
          // }

          // public static Payment ToPaymentObj(string payment)
          // {
          //      var payObj = payment.Split('\t');
          //      var id = int.Parse(payObj[0]);
          //      var beneficiaryWalletId = payObj[1];
          //      var benefactorWalletId = payObj[2];
          //      var pin = int.Parse(payObj[3]);
          //      var amount = double.Parse(payObj[4]);
          //      var paymentRefNumber = payObj[5];
          //      var isDeleted = bool.Parse(payObj[6]);
          //      var dateCreated = DateTime.Parse(payObj[7]);

          //      return new Payment(id, beneficiaryWalletId, benefactorWalletId, pin, amount, paymentRefNumber, isDeleted, dateCreated);
          // }
     }
}