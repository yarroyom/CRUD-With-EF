using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_PROGRA1_FINAL
{
    public class Employee
    {
        [Key]
public int EmpID { get; set; }
      
        public string Name { get; set; }
      
        public string Email { get; set; }
      
        public string Fecha { get; set; }
      
        public string Direccion { get; set; }

        public string ImageUrl { get; set; }

    }
}
