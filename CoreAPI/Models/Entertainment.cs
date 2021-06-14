using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Entertainment
    {
        
        //public int Id { get; set; }
        public string Category { get; set; }
        public string Question { get; set; }
        public string[] TotalOptions { get; set; }
        public string CorrectAnswer { get; set; }
    }

}
