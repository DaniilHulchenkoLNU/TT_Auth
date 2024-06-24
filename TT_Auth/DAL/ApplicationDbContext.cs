using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TT_Auth.Models.Entity;



namespace TT_Auth.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserInfo>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = true;
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<ApprovalRequest> ApprovalRequests { get; set; }
        public DbSet<LeaveRequests> LeaveRequests { get; set; }
        public DbSet<Project> Projects { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseLazyLoadingProxies();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.PeoplePartner)
            .WithMany(e => e.PeoplePartners)
            .HasForeignKey(e => e.PeoplePartnerId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Role)
            .WithMany()
            .HasForeignKey(e => e.RoleId);

        modelBuilder.Entity<LeaveRequests>()
            .HasOne(lr => lr.Employee)
            .WithMany(e => e.LeaveRequests)
            .HasForeignKey(lr => lr.EmployeeId)
            .OnDelete(DeleteBehavior.NoAction);


        modelBuilder.Entity<ApprovalRequest>()
            .HasOne(ar => ar.Approver)
            .WithMany(e => e.ApprovalRequests)
            .HasForeignKey(ar => ar.ApproverId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ApprovalRequest>()
            .HasOne(ar => ar.LeaveRequest)
            .WithMany(lr => lr.ApprovalRequests)
            .HasForeignKey(ar => ar.LeaveRequestId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<UserInfo>()
            .HasOne(u => u.Employee)
            .WithOne(e => e.UserInfo)
            .HasForeignKey<Employee>(e => e.UserInfoId)
            .OnDelete(DeleteBehavior.Cascade);
            SeedData(modelBuilder);

    }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // UserInfo data
        var user1 = new UserInfo
        {
            Id = "1",
            UserName = "john.doe",
            Email = "john.doe@example.com",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEBaKxU/EG+u0C5pW/VsH1jRZ0o1a+uzt4ToOeZ1dr6iST4lbk4Fomg==",
            SecurityStamp = "JBSY6Z5DZGPMZ5MN4NXQ4KOB4HCEAQ6Z",
            ConcurrencyStamp = "9ae6fe15-15b8-4c5b-9e0c-6751b6c6d8f1",
            PhoneNumber = "1234567890",
            LockoutEnabled = true,
        };

        var user3 = new UserInfo
        {
            Id = "2",
            UserName = "alex.smith",
            Email = "alex.smith@example.com",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEIJJR3+K7G9QXmJH5Nl5G5RZ0o1a+uzt4ToOeZ1dr6iST4lbk4Fomg==",
            SecurityStamp = "ABSJ6Z5DZGPMZ5MN4NXQ4KOB4HCEAQ6Z",
            ConcurrencyStamp = "8be6fe15-15b8-4c5b-9e0c-6751b6c6d8f1",
            PhoneNumber = "1231231234",
            LockoutEnabled = true,
        };
        // Role data
        var role1 = new Role
        {
            Id = 1,
            RoleName = "Admin",
            Description = "Administrator role with full permissions"
        };

        var role2 = new Role
        {
            Id = 2,
            RoleName = "User",
            Description = "Regular user role with limited permissions"
        };

        // Employee data
        var employee1 = new Employee
        {
            Id = 1,
            UserInfoId = user1.Id,
            //FullName = "John Doe",
            Subdivision = "IT",
            Position = "Developer",
            Status = "Active",
            OutOfOfficeBalance = 10,
            Photo = "photo_url_1",
            RoleId = role2.Id
        };

        var employee3 = new Employee
        {
            Id = 2,
            UserInfoId = user3.Id,
            //FullName = "Alex Smith",
            Subdivision = "Marketing",
            Position = "Analyst",
            Status = "Active",
            OutOfOfficeBalance = 5,
            Photo = "photo_url_3",
            RoleId = role2.Id
        };


        // Permission data
        var permission1 = new Permission
        {
            Id = 1,
            PermissionName = "Read",
        };

        var permission2 = new Permission
        {
            Id = 2,
            PermissionName = "Write",
        };

        // LeaveRequest data
        var leaveRequest1 = new LeaveRequests
        {
            Id = 1,
            EmployeeId = 1,
            AbsenceReason = "Vacation",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(10),
            Status = "New",
            Comment = "Annual vacation" // Указываем значение для Comment
        };

        var leaveRequest2 = new LeaveRequests
        {
            Id = 2,
            EmployeeId = 2,
            AbsenceReason = "Medical",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(5),
            Status = "New",
            Comment = "Medical leave" // Указываем значение для Comment
        };

        // ApprovalRequest data
        var approvalRequest1 = new ApprovalRequest
        {
            Id = 1,
            ApproverId = 2,
            LeaveRequestId = 1,
            Status = "Approved",
            Comment = "Enjoy your vacation!",
        };

        var approvalRequest2 = new ApprovalRequest
        {
            Id = 2,
            ApproverId = 1,
            LeaveRequestId = 2,
            Status = "Pending",
            Comment = "Get well soon!",
        };

        // Project data
        var project1 = new Project
        {
            Id = 1,
            ProjectType = "Internal",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(6),
            ProjectManagerId = 1,
            Status = "Active",
            Comment = "Project A description",
        };

        var project2 = new Project
        {
            Id = 2,
            ProjectType = "External",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(3),
            ProjectManagerId = 2,
            Status = "Active",
            Comment = "Project B description",
        };





        modelBuilder.Entity<UserInfo>().HasData(user3);
        modelBuilder.Entity<Employee>().HasData(employee3);


        modelBuilder.Entity<UserInfo>().HasData(user1);
        modelBuilder.Entity<Employee>().HasData(employee1);

        modelBuilder.Entity<Role>().HasData(role1, role2);
        modelBuilder.Entity<Permission>().HasData(permission1, permission2);
        
        modelBuilder.Entity<ApprovalRequest>().HasData(approvalRequest1, approvalRequest2);
        modelBuilder.Entity<Project>().HasData(project1, project2);
        modelBuilder.Entity<LeaveRequests>().HasData(leaveRequest1, leaveRequest2);
        }
}
}