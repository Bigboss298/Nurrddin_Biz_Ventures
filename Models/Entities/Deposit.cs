namespace My_Project_Continued.Models
{
    public class Deposit : BaseEntity
    { 
        public string WalletId;
        public double Amount;
        public int WalletPin;
        public string DepositRefNumber;

          public Deposit(int id, string walletId, double amount, int walletPin, string depositRefNumber, bool isDeleted, DateTime dateCreated) : base(id, isDeleted, dateCreated)
          {
               WalletId = walletId;
               Amount = amount;
               WalletPin = walletPin;
               DepositRefNumber = depositRefNumber;
          }
          // public override string ToString()
          // {
          //      return $"{Id}\t{WalletId}\t{Amount}\t{WalletPin}\t{DepositRefNumber}\t{IsDeleted}\t{DateCreated}";
          // }
          // public static Deposit ToDepositObj(string deposit)
          // {
          //      var depositObj = deposit.Split('\t');
          //      var id = int.Parse(depositObj[0]);
          //      var walletId = depositObj[1];
          //      var amount = double.Parse(depositObj[2]);
          //      var walletPin = int.Parse(depositObj[3]);
          //      var depositRefNumber = depositObj[4];
          //      var isDeleted = bool.Parse(depositObj[5]);
          //      var dateCreated = DateTime.Parse(depositObj[6]);

          //      return new Deposit(id, walletId, amount, walletPin, depositRefNumber, isDeleted, dateCreated);
          // }
     }
}