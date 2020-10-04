using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiWithASP.Net.Models
{
    public class NewOffice
    {
        public int Id { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Name { get; set; }
    }
}