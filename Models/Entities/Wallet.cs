using My_Project_Continued.Models.Enums;

namespace My_Project_Continued.Models
{
    public class Wallet : BaseEntity
    {
        public string WalletName;
        public string WalletId;
        public double WalletBalance;  
        public int WalletPin;
        public WalletType WalletType;
        public Location Location;
        public string LocationBranch;
        
     //    public string ReferenceNumber;

          public Wallet(int id, string walletName, string walletId, double walletBalance, int walletPin, WalletType walletType, Location location, bool isDeleted, DateTime dateCreated) : base(id, isDeleted, dateCreated)
          {
               WalletName = walletName;
               WalletId = walletId;
               WalletBalance = walletBalance;
               WalletPin = walletPin;
               WalletType = walletType;
               Location = location;
               LocationBranch = $"{this.Location.ToString()} Branch";
               // ReferenceNumber = referenceNumber;
          }

          // public override string ToString()
          // {
          //      return $"{Id}\t{WalletName}\t{WalletId}\t{WalletBalance}\t{WalletPin}\t{WalletType}\t{IsDeleted}\t{DateCreated}";
          // }

          // public static Wallet ToWallet(string wallet)
          // {
          //      var walletObj = wallet.Split('\t');
          //      var id = int.Parse(walletObj[0]);
          //      var walletName = walletObj[1];
          //      var walletId = walletObj[2];
          //      var walletBalance = double.Parse(walletObj[3]);
          //      var walletPin = int.Parse(walletObj[4]);
          //      var walletType = Enum.TryParse(walletObj[5], out WalletType walt);
          //      var isDeleted = bool.Parse(walletObj[6]);
          //      var dateCreated = DateTime.Parse(walletObj[7]);

          //      return new Wallet(id, walletName, walletId, walletBalance, walletPin, walt, isDeleted, dateCreated);
          // }
     }
}


// WALTID/NBV/007