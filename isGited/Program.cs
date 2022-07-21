using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;
using System.Threading.Tasks;

using isGited_App;

namespace isGited
{
    class Program
    {
        static void Main(string[] args)
        {
            app app = new app();
            app.SearchInFiles(@"D:\projekte\", ".git");
        }
    }
}
