using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.AspNet.Identity.EntityFramework;


namespace TT_Auth.Models.Entity
{
    [Table("Employees")]
    public class Employee : DbBase
    {
        public Employee()
        {
            Position = "Rookie";
            Subdivision = "Unknown";
            Status = "Active";
            OutOfOfficeBalance = 0;
            //Role = (await _RoleRepository.GetAll()).FirstOrDefault(r => r.RoleName == "User");
            //RoleId = 2;
            Photo = "default.jpg";
        }

        public string UserInfoId { get; set; }

        [ForeignKey("UserInfoId")]
        public virtual UserInfo UserInfo { get; set; }


        [Required]
        public string Subdivision { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Status { get; set; }  // Active/Inactive

        public int? PeoplePartnerId { get; set; }

        [Required]
        public float OutOfOfficeBalance { get; set; }

        public string Photo { get; set; }  // Optional field for photo

        //[Required]
        //public int RoleId { get; set; }
        
        //[ForeignKey("RoleId")]
        //public virtual Role Role { get; set; }

        [ForeignKey(nameof(PeoplePartnerId))]
        public virtual Employee PeoplePartner { get; set; }

        public virtual ICollection<Employee> PeoplePartners { get; set; } = new List<Employee>();

        public virtual ICollection<LeaveRequests> LeaveRequests { get; set; } = new List<LeaveRequests>();

        public virtual ICollection<ApprovalRequest> ApprovalRequests { get; set; } = new List<ApprovalRequest>();
    }
}
