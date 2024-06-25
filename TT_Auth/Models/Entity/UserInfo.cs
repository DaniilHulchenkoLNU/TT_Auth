using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TT_Auth.Models.Entity
{
    public class UserInfo : IdentityUser
    {
        //[Key, ForeignKey(nameof(Employee))]
        //public int UserID { get; set; }
        //public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; } = new List<IdentityUserClaim<string>>();
        //public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; } = new List<IdentityUserLogin<string>>();
        //public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; } = new List<IdentityUserToken<string>>();
        //public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; } = new List<IdentityUserRole<string>>();  


        public int RoleId { get; set; } = 2;
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
