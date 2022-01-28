using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
   public class Employeeentity
    {
        [ScaffoldColumn(false)]
        public int EMPId { get; set; }
        public string EMPCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public int RoleId { get; set; }
        public string ReportingToId { get; set; }
        //[[ReportingToId]]
    }
}
