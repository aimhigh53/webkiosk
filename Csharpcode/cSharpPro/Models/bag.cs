using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cSharpPro.Models
{
    public static class Bag
    {
        public static string Rpicked { get; set; }

        public static string Rprice { get; set; }

        public static string age { get; set; }

        public static int count = 0;

        static void SetRpicked(string var)
        {
            Rpicked += var + ',';
        }
        static void SetRprice(string var)
        {
            Rprice += var + ',';
        }

        static string GetRpicked()
        {
            return Rpicked;
        }
        static string GetRprice()
        {
            return Rprice;
        }
    }
}
