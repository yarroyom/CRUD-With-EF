using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_PROGRA1_FINAL
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base("name=con") { }
        public DbSet<Employee> Emplist { get; set; }

    }
}
