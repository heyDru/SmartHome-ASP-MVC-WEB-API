using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService;
using Models.Model.Implementation;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DevicesContext db = new DevicesContext())
            {
                Console.WriteLine(db.Lamps.Count());
            }

        }
    }
}
