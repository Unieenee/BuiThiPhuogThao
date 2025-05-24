namespace BuiThiPhuongThao.Models;
 public class AssignRoleVM
    {
        public string UserId { get; set; }
        public IList<RoleVM> AllRole { get; set; } = new List<RoleVM>();
        public IList<string> SelectedRole { get; set; } = new List<string>();
    }