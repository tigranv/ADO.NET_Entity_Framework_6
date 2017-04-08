using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First_Existing_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ModelCFEDB container = new ModelCFEDB())
            {
                var list = container.PersonalInfoes.ToList();

                foreach (var item in list)
                {
                    Console.WriteLine($"{item.Id} - {item.FirstName} {item.LastName} {item.Age}");
                }
            }

            Console.ReadKey();
        }
    }
}
