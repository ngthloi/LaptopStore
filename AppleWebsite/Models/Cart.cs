using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using AppleWebsite.Identity;
namespace AppleWebsite.Models
{
	public class Cart
	{
		[Key]
		public int id_cart { get; set; }
		public int id_dev { get; set; }
		public Nullable<int> quantity { get; set; }
		public string storage { get; set; }
		public virtual Device Device { get; set; }

		public string id_user { get; set; }
	}
}