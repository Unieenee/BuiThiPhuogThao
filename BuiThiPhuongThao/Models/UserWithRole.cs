namespace BuiThiPhuongThao.Models;
  public class UserWithRole
    {
        public AppUser? User { get; set; }
        public IList<string>? Role { get; set; }
    }