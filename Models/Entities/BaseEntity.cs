namespace My_Project_Continued.Models
{
    public class BaseEntity
    {
        public int Id;
        public bool IsDeleted;
        public DateTime DateCreated;
          public BaseEntity(int id, bool isDeleted, DateTime dateCreated)
          {
               Id = id;
               IsDeleted = isDeleted;
               DateCreated =  dateCreated;

          }
     }
}