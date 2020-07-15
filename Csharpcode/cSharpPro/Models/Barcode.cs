using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cSharpPro.Models
{
    public class Barcode
    {

        [Key] //pk설정
        public int BarcodeNum { get; set; }

        [Required]
        public string BarcodeContent { get; set; }
    }
}
