using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;
using System.Threading.Tasks;

using isGited_App;
using isGited_withoutRc;

namespace isGited
{
    class Program
    {
        static void Main(string[] args)
        {
            //app app = new app();
             withoutRc app = new  withoutRc();
            app.SearchInFiles(@"/Users/snow/development/", ".git");
        }
    }
}
