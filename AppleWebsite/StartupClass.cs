using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using AppleWebsite.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;
[assembly: OwinStartup(typeof(AppleWebsite.StartupClass))]

namespace AppleWebsite
{
	public class StartupClass
	{
		public void Configuration(IAppBuilder app)
		{
			app.UseCookieAuthentication(new CookieAuthenticationOptions()
			{
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, // chỉ định trang này sử dụng cookies
				LoginPath = new PathString("/Account/Login") // đây là path mỗi khi unauthencation thì sẽ điều hướng về
			});
			this.CreateRolesAndUser();
		}
		public void CreateRolesAndUser()
		{
			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AppDbContext()));
			var appDbContext = new AppDbContext();
			var appUserStore = new AppUserStore(appDbContext);
			var userManager = new AppUserManager(appUserStore);
			// create role Admin
			if(!roleManager.RoleExists("Admin"))
			{
				var role = new IdentityRole();
				role.Name = "Admin";
				roleManager.Create(role);
			}
			if(userManager.FindByName("admin")== null)
			{
				var user = new AppUser();
				user.UserName = "admin";
				user.Email = "admin@gmail.com";
				string userPwd = "admin123";
				user.Birthday = DateTime.Now;

				var chkUSer = userManager.Create(user, userPwd);
				if(chkUSer.Succeeded)
				{
					userManager.AddToRole(user.Id, "Admin");
				}
			}

			// create role manager
			if (!roleManager.RoleExists("Manager"))
			{
				var role = new IdentityRole();
				role.Name = "Manager";
				roleManager.Create(role);
			}
			if (userManager.FindByName("manager") == null)
			{
				var user = new AppUser();
				user.UserName = "manager";
				user.Email = "manager@gmail.com";
				string userPwd = "manager123";
				user.Birthday = DateTime.Now;
				var chkUSer = userManager.Create(user, userPwd);
				if (chkUSer.Succeeded)
				{
					userManager.AddToRole(user.Id, "Manager");
				}
			}
			//create role customer
			if (!roleManager.RoleExists("Customer"))
			{
				var role = new IdentityRole();
				role.Name = "Customer";
				roleManager.Create(role);
			}
		}
	}
}
