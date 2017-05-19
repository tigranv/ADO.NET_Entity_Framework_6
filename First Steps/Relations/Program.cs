using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relations
{
    class Program
    {
        static void Main(string[] args)
        {
            DoWork().Wait();
            Console.ReadKey();
        }

        private static async Task DoWork()
         {
             var db = new TestDatabaseProjectEntities();
 
            //db.Students.Add(new Student {
            //     FName = "Poghas",
            //     LName = "Petros"
            // });
 
            // try
            // {
            //     await db.SaveChangesAsync();
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine(ex.InnerException.Message);
            // }
 
             

            List<Student> students = await db.Students
                .Include(p => p.Phones)
                .Where(p => p.FName.ToLower().Contains("a"))
                .ToListAsync();

            foreach (var st in students)
            {
                Console.WriteLine($" {st.Id} {st.FName} {st.LName} {st.Phones.Count}");
                Console.WriteLine(st.Alias);

                st.Alias = "bbba";
                //db.Phones.Add();
                //db.Students.AddOrUpdate(st);
                db.Entry<Student>(st).State = EntityState.Modified;
            }

            var grzo = await db.Students
                .FirstOrDefaultAsync(p => p.FName == "khachik" && p.LName == "Sukiasyan");
            
            if(grzo != null)
            {
                grzo.Alias = "Grzo";
            }
            else
            {
                db.Students.Add(
                    new Student() { FName = "khachik", LName = "Sukiasyan"});
             
            }
             await   db.SaveChangesAsync();

        }
    }
}
