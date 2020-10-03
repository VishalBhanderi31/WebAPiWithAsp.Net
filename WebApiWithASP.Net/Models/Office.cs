using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiWithASP.Net.Models
{
    public class Office
    {
        public int Id { get; set; }

        [Required]
        public string Location { get; set; }
        
        //Foreign key
        public int EmployeeId { get; set; }
        //Navigation Property
        public Employee Employee { get; set; }
    }
} 