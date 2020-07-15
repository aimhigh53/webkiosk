using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cSharpPro.Models
{
    public class GetBucket
    {
        private string[] menu = new string[100];
        private int number = 0;
        void setMenu (string Menu)
        {
            menu[number] = Menu;
            number++;
        }
        string[] getMenu ()
        {
            return menu;
        }
    }
}
