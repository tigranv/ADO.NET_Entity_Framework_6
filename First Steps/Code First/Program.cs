using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First
{
    class Program
    {
        static void Main(string[] args)
        {
            MOdelCF contex = new MOdelCF();

            contex

            var list = contex.PersonalInfos.ToList();

            foreach (var item in list)
            {
                Console.WriteLine($"{item.Id}, {item.FirstName}");
            }
        }
    }
}
