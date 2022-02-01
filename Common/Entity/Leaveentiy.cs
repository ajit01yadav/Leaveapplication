using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace Common.Entity
{

    public class Leaveentiy
    {
        [ScaffoldColumn(false)]
        public int leaveId { get; set; }

      //  [Required(ErrorMessage = Validations.Leave.FromDate)]
       // [Display(Name = Validations.Leave.FromDate)]

       
       // [Column(TypeName = "date")]
       // [DataType(DataType.Date)]
       // [DisplayFormat(DataFormatString = "{0:dd/mm/yy}")]

      // public DateTime? Fromdate { get; set; }
        public string Fromdate { get; set; }

       // [Required(ErrorMessage = Validations.Leave.Todate)]
        // [RegularExpression(Validations.Leave.Todate, ErrorMessage = Validations.Leave.ToDateRequired)]
       // [Display(Name = Validations.Leave.Todate)]
        // [Column(TypeName = "date")]
        //[DisplayFormat(DataFormatString = "{0:dd/mm/yy}")]
        // [DataType(DataType.Date)]
        //public DateTime? Todate { get; set; }
        public string Todate { get; set; }



        [Required(ErrorMessage = Validations.Leave.leavereason)]
        [AllowHtml]
        [Display(Name = Validations.Leave.leavereason)]

        public string leavereason { get; set; }
        [AllowHtml]
        [Display(Name = Validations.Leave.leavetype)]
        public string LeaveStatusID { get; set; }
        [AllowHtml]
        [Display(Name = Validations.Leave.leavetype)]
        public string leavetype { get; set; }

        public int leavebalance { get; set; }
        [DisplayName("Balance Leave :CL")]
        public decimal Casual_Leave { get; set; }
        [DisplayName("Balance Leave :PL")]
        public decimal PL { get; set; }
        public DateTime? createdon { get; set; }
        // public DateTime? updatedon { get; set; }
        public string updatedby { get; set; }
        //  public string Leavetypeid { get; set; }

        public string Description { get; set; }
        public int EmpID { get; set; }
        [AllowHtml]
        [Display(Name = Validations.Leave.leavecount)]
       // public float leavecount { get; set; }
        public decimal leavecount { get; set; }
        [DisplayName("Half day")]
        public string Date { get; set; }
        public string[] DynamicTextBox { get; set; }
        //[Required(ErrorMessage = Validations.Leave.StatusRequired)]
        //[Display(Name = Validations.Leave.Status)]
        public int Status { get; set; }
       
    }
}

