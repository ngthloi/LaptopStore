using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppleWebsite.Models
{
    public class Device
	{
        [Key]
        public int id_dev { get; set; }
        [Display(Name ="Device")]
        public string name_dev { get; set; }
        [Display(Name = "Price")]
        public double cost { get; set; }
        public string img { get; set; }
        [Display(Name = "Storage")]
        public string storage { get; set; }
        [Display(Name = "Category")]
        public int id_cate { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
    }
}