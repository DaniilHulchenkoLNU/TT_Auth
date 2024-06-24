using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT_Auth.Models.Entity
{
    [Table("Permissions")]
    public class Permission: DbBase
    {

        [Required]
        public string PermissionName { get; set; }

        public virtual List<Role> Roles { get; set; }
    }
}
