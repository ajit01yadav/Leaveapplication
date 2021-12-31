using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public class Leaveentiy
    {
        [ScaffoldColumn(false)]
        public int leaveId { get; set; }

        [Required(ErrorMessage = Validations.Leave.FromDate)]
      // [RegularExpression(Validations.Leave.FromDate, ErrorMessage = Validations.Leave.FromDateRequired)]
       [Display(Name = Validations.Leave.FromDate)]
        // [Column(TypeName = "date")]
      //  string str = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'");
       //  public DateTime? Fromdate { get; set; }
        public string Fromdate { get; set; }



        [Required(ErrorMessage = Validations.Leave.Todate)]
       // [RegularExpression(Validations.Leave.Todate, ErrorMessage = Validations.Leave.ToDateRequired)]
        [Display(Name = Validations.Leave.Todate)]
       // [Column(TypeName = "date")]
        // public DateTime? Todate { get; set; }
        public string Todate { get; set; }


        //  public string LastName { get; set; }

        //  [DisplayName("From date :")]
        // [DisplayFormat(DataFormatString ="{0:dd-MMM-yyyy}",ApplyFormatInEditMode =true)]
        // [Required(ErrorMessage = "Please select From date")]
        //  public DateTime? Fromdate { get; set; }
        // public DateTime? ErrorFromDate { get; set; }
        // [DisplayName("To date :")]
        // [Required(ErrorMessage = "Please select To date")]
        // public DateTime? Todate { get; set; }
        // [DisplayName("Leave reason :")]
        [Required(ErrorMessage = Validations.Leave.leavereason)]
      //  [RegularExpression(Validations.Leave.leavereason, ErrorMessage = Validations.Leave.LeavereasonRequired)]
        [Display(Name = Validations.Leave.leavereason)]

        public string leavereason { get; set; }
        

       // [Required(ErrorMessage = Validations.Leave.LeaveStatusID)]
       // [RegularExpression(Validations.Leave.Leavetype, ErrorMessage = Validations.Leave.LeavetypeRequired)]
        [Display(Name = Validations.Leave.leavetype)]
        public string LeaveStatusID { get; set; }

        public string leavetype { get; set; }

        public int leavebalance { get; set; }
        [DisplayName("Balance leave :CL")]
        public int Casual_Leave { get; set; }
        [DisplayName("Balance leave :PL")]
        public int PL { get; set; }
        public DateTime? createdon { get; set; }
       // public DateTime? updatedon { get; set; }
        public string updatedby { get; set; }
        //  public string Leavetypeid { get; set; }
      
        public string Description { get; set; }
        public int EmpID { get; set; }
        [DisplayName("Total number of Days")]
        public float leavecount { get; set; }

    }
  
}
