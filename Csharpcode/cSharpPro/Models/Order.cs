using System;
using System.ComponentModel.DataAnnotations;

namespace cSharpPro.Models
{
    public class Order
    {   
        [Key]
        public int age { get; set; }

        public string burger { get; set; }

        public string side { get; set; }

        public string beverage { get; set; }


    }
}
