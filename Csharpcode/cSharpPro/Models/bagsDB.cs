using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cSharpPro.Models
{
    [Table("bagdbs")]
    public class bagsDB
    {

        [Key] //pk설정
        public string NO { get; set; }

        public string Age { get; set; }
        
        public string picked{ get; set; }

    
        public string price{ get; set; }

    }
}
