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
    public class HRentity
    {
        public int HR_ID { get; set; }
        public string Emailid { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastModifiedById { get; set; }
        public int LastModifiedDate { get; set; }
      
        //[LastModifiedById]


    }
}
