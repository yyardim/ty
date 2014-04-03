using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TY.Data;
using TY.Model;

namespace TY.DbConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TyDbContext())
            {
                var p = db.Persons.FirstOrDefault();

            }
        }
    }
}
