using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TT_Auth.Models.Entity
{
    [Table("Roles")]
    public class Role : DbBase
    {

        [Required]
        public string RoleName { get; set; }

        [Required]
        public string Description { get; set; }

        //public virtual List<Employee> Employees { get; set; }

        public virtual List<Permission> Permissions { get; set; }
    }
}
