using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_First
{
    class Program
    {
        // example on Model First in EF
        static void Main(string[] args)
        {
            using (MyModel1Container container = new MyModel1Container())
            {
                container.PersonalInfoes.Add(new PersonalInfo {FirstName = "Levon", LastName = "Vardanyan", Age = 59 });
                container.PersonalInfoes.Add(new PersonalInfo {FirstName = "Laura", LastName = "Mkrtchyan", Age = 61 });
                container.SaveChanges();

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
