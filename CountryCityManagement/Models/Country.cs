using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountryCityManagement.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [Required(ErrorMessage = "Please enter country name!")]
        [Remote("CheckName", "Country", ErrorMessage = " Name must be unique")]
        public string Name { set; get; }
        [AllowHtml]
        [Required(ErrorMessage = "Please fill country information!")]
        public string About { set; get; }
        [DisplayName("Upload Image")]
        //[Required(ErrorMessage = "Please upload image!")]
        public string ImageLocation { set; get; }


    }
}