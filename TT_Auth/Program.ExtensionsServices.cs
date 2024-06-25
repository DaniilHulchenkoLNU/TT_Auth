using DAL.Implementations;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TT_Auth.Data;
using TT_Auth.Models.Entity;


namespace TT_Auth
{
    public static class ExtensionsServices
    {

        public static void AddMyServices(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            //IdentityUser
            builder.Services.AddDefaultIdentity<UserInfo>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddScoped<IUserClaimsPrincipalFactory<UserInfo>, CustomUserClaimsPrincipalFactory>();


            //builder.Services.AddIdentity<UserInfo, IdentityRole>(options =>
            //{
            //    //options.SignIn.RequireConfirmedAccount = true;
            //})
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireRoleAdmin1", policy =>
                    policy.RequireClaim("RoleId", "1"));
            });


            builder.Services.AddScoped(typeof(iBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddTransient<iUserInfoRepository, UserInfoRepository>();

            //builder.Services.AddScoped<AccountService>();
            //builder.Services.AddScoped<EmployeeService>();
        }

    }
}
