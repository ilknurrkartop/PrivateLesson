using PrivateLesson.Entity.Concrete.Identity;

namespace PrivateLesson.WebUI.Areas.Admin.Models.ViewModels.Accounts
{
    public class RoleUpdateViewModel
    {
        public Role Role { get; set; }
        public List<User> Members { get; set; }
        public List<User> NonMembers { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToRemove { get; set; }
    }
}
