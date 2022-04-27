using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

//public class ViewModel
//{
//    public List<Leaveentiy> ApproveRejectlist { get; set; }
//    public List<ApproveRejectEntity> FilteronAprrove { get; set; }
//}


public class Leaveentiy
    {   
        [ScaffoldColumn(false)]
        public int leaveId { get; set; }
        //[RegularExpression(Validations.RegularExpression.DateFormat)]
        [RegularExpression(Validations.RegularExpression.DateFormat, ErrorMessage = Validations.Leave.FromDateError)]
        [Required(ErrorMessage = Validations.Leave.FromDate)]
        [Display(Name = Validations.Leave.FromDate)]

        public string Fromdate { get; set; }
       // public DateTime Fromdate { get; set; }
       [RegularExpression(Validations.RegularExpression.DateFormat, ErrorMessage = Validations.Leave.ToDateError)]
        [Required(ErrorMessage = Validations.Leave.Todate)]
      
        [Display(Name = Validations.Leave.Todate)]
       
        public string Todate { get; set; }

      // public DateTime Todate { get; set; }

        [Required(ErrorMessage = Validations.Leave.leavereason)]
        [AllowHtml]
        [Display(Name = Validations.Leave.leavereason)]

        public string leavereason { get; set; }
        [Required(ErrorMessage = Validations.Leave.leavetype)]
        [AllowHtml]
        [Display(Name = Validations.Leave.leavetype)]
        public string LeaveStatusID { get; set; }
       // [Required(ErrorMessage = Validations.Leave.leavetype)]
        [AllowHtml]
        [Display(Name = Validations.Leave.leavetype)]
        public string leavetype { get; set; }

        public int ? leavebalance { get; set; }
        [DisplayName("Balance Leave :CL")]
        public decimal Casual_Leave { get; set; }
        [DisplayName("Balance Leave :PL")]
        public decimal PL { get; set; }
        public DateTime? createdon { get; set; }
        // public DateTime? updatedon { get; set; }
        public string updatedby { get; set; }
    //  public string Leavetypeid { get; set; }
        [Display(Name = Validations.Leave.Compoffleave)]
        public string Description { get; set; }
        public int EmpID { get; set; }
        [AllowHtml]
        [Display(Name = Validations.Leave.leavecount)]
       // public float leavecount { get; set; }
        public decimal leavecount { get; set; }
        [DisplayName("Half day")]
        public string Date { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
    public string[] DynamicTextBox { get; set; }

        public int Status { get; set; }

        public string EMPCode { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string Rejectionreason { get; set; }

        public string halfdayid { get; set; }

        public string ReportingToId { get; set; }

        public bool IsHalfdaySelect { get; set; }

       public bool IsApproved { get; set; }

       public bool IsRejected { get; set; }

       public int IsHomepage { get; set; }
       public int EntityType { get; set; }
       public string EntityID { get; set; }

       public int PageTypeID { get; set; }


}
public class ApproveRejectEntity
{
    [ScaffoldColumn(false)]
    public int leaveId { get; set; }
    //[RegularExpression(Validations.RegularExpression.DateFormat)]
    [RegularExpression(Validations.RegularExpression.DateFormat, ErrorMessage = Validations.Leave.FromDateError)]
    [Required(ErrorMessage = Validations.Leave.FromDate)]
    [Display(Name = Validations.Leave.FromDate)]

    public string Fromdate { get; set; }
    [RegularExpression(Validations.RegularExpression.DateFormat, ErrorMessage = Validations.Leave.ToDateError)]
    [Required(ErrorMessage = Validations.Leave.Todate)]

    [Display(Name = Validations.Leave.Todate)]

    public string Todate { get; set; }

    [Required(ErrorMessage = Validations.Leave.leavereason)]
    [AllowHtml]
    [Display(Name = Validations.Leave.leavereason)]

    public string leavereason { get; set; }
    [Required(ErrorMessage = Validations.Leave.leavetype)]
    [AllowHtml]
    [Display(Name = Validations.Leave.leavetype)]
    public string LeaveStatusID { get; set; }
    // [Required(ErrorMessage = Validations.Leave.leavetype)]
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

    public int Status { get; set; }
    public string EMPCode { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }

    public string Rejectionreason { get; set; }

    public string halfdayid { get; set; }
    public string ReportingToId { get; set; }


}

public class ApproveStatusentity
    {
       public int Status_id { get; set; }
        public string Status { get; set; }
    }
public class Halfdayentity
{
    public string[] DynamicTextBox { get; set; }
    public int halfdayid { get; set; }
    public string Date { get; set; }
    public DateTime? Createdon { get; set; }
    public DateTime? Updatedon { get; set; }


}


