namespace ParcleManagement.Data.Models
{
    public class UserRole
    {
        public int UserID { get; set; }
        public User User { get; set; }

        public int RoleTypeID { get; set; }
        public RoleType RoleType { get; set; }
    }
}