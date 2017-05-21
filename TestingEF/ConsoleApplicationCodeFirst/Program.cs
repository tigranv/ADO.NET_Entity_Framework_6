using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            CodefirstCRMDB db = new CodefirstCRMDB();
            db.EmailLists.ToList();
        }
    }
}
