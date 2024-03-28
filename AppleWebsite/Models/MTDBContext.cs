using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace AppleWebsite.Models
{
	public class MTDBContext:DbContext
	{
		public MTDBContext() : base("AppleConnectionString")
		{

		}
		public DbSet<Device> Devices { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Cart> Carts { get; set; }
	}
}