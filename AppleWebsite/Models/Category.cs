    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppleWebsite.Models
{
	public class Category
	{
		[Key]
		public int id_cate { get; set; }
		public string name_cate { get; set; }
		public virtual ICollection<Device> devices { get; set; }
	}
}