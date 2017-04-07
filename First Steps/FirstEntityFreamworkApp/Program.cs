using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEntityFreamworkApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDatabaseEntities contex = new MyDatabaseEntities();

            // here table is like row

            List<Table> list = contex.Tables.ToList();

            foreach (Table item in list)
            {

            }
        }
    }
}
