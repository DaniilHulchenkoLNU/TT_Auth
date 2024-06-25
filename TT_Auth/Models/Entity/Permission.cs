using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TT_Auth.Models.Entity
{
    [Table("Permissions")]
    public class Permission : DbBase
    {

        [Required]
        public string PermissionName { get; set; }

        public virtual List<Role> Roles { get; set; }
    }
}
