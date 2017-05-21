using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCleinttest89
{
    class Program
    {
        static void Main(string[] args)
        {
            BetC_CRM_DatabaseEntitiesTest89 db = new BetC_CRM_DatabaseEntitiesTest89();

            var list = db.Partners.ToList();
            foreach (var item in list)
            {
                Console.WriteLine(item.EmailLists.Count);
            }

            Console.ReadKey();
        }
    }
}
