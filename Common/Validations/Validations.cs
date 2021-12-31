using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Validations
{
    public static string LogsAdd = "New Record Created";
    public static string LogsEdit = "Record Updated";
    public static string LogsDelete = "Record Deleted";
    public const string RequiredTextInitials = "Please specify ";
    public const string ErrorTextInitials = "Please specify valid ";
    public const string RequiredSelectInitials = "Please select ";
    public const string RequiredImageInitials = "Please upload ";
    public const string ErrorSelectInitials = "Please select valid ";
    public const string ErrorUploadInitials = "Please upload valid ";


    public class User
    {
        public const string FirstName = "First Name";
        public const string FirstNameRequired = RequiredTextInitials + FirstName;
        public const string FirstNameError = ErrorTextInitials + FirstName;

        public const string LastName = "Last Name";
        public const string LastNameRequired = RequiredTextInitials + LastName;
        public const string LastNameError = ErrorTextInitials + LastName;

        public const string Email = "Email";
        public const string EmailRequired = RequiredTextInitials + Email;
        public const string EmailError = ErrorTextInitials + Email;

        public const string Password = "Password";
        public const string PasswordRequired = RequiredTextInitials + Password;
        public const string PasswordError = ErrorTextInitials + Password;

        public const string Role = "Role";
        public const string RoleRequired = RequiredSelectInitials + Role;
        public const string RoleError = ErrorSelectInitials + Role;

        public const string Status = "Status";
        public const string StatusRequired = RequiredSelectInitials + Status;
    }
    public class Leave
    {
        public const string FromDate = "From Date";
        public const string FromDateRequired = RequiredTextInitials + FromDate;
        public const string FromDateError = ErrorTextInitials + FromDate;

        public const string Todate = "To date";
        public const string ToDateRequired = RequiredTextInitials + Todate;
        public const string ToDateError = ErrorTextInitials + Todate;

        public const string leavereason = "Leave Reason";
        public const string LeavereasonRequired = RequiredTextInitials + leavereason;
        public const string LeavereasonError = ErrorTextInitials + leavereason;

        //public const string LeaveStatusID = "Leave type";
        //public const string LeavetypeRequired = RequiredTextInitials + LeaveStatusID;
        //public const string LeavetypeError = ErrorTextInitials + LeaveStatusID;

        public const string leavetype = "Leave type";
        public const string leavetypeRequired = RequiredTextInitials + leavetype;
        public const string leavetypeError = ErrorTextInitials + leavetype;


        //public const string Role = "Role";
        //public const string RoleRequired = RequiredSelectInitials + Role;
        //public const string RoleError = ErrorSelectInitials + Role;

        //public const string Status = "Status";
        //public const string StatusRequired = RequiredSelectInitials + Status;
    }
    public class Login
    {
        public const string Email = "Email";
        public const string EmailRequired = RequiredTextInitials + Email;
        public const string EmailError = ErrorTextInitials + Email;

        public const string Fromdate = "Fromdate";
        public const string FromdateRequired = RequiredTextInitials + Fromdate;
        public const string FromdateError = ErrorTextInitials + Fromdate;

        public const string Password = "Password";
        public const string PasswordRequired = RequiredTextInitials + Password;
    }
    public class ForgotPassword
    {
        public const string Email = "Email";
        public const string EmailRequired = RequiredTextInitials + Email;
        public const string EmailError = ErrorTextInitials + Email;
    }

    

    public class ChangePassword
    {
        public const string Password = "Current Password";
        public const string PasswordRequired = RequiredTextInitials + Password;

        public const string NewPassword = "New Password";
        public const string NewPasswordRequired = RequiredTextInitials + NewPassword;

        public const string NewPasswordMatch = "New password and re-type new password should match";
    }

    public class RegularExpression
    {
        public const string NameValidation = @"^[a-zA-Z\s' ]+$";

        public const string EmailValidation = @"^([A-Za-z0-9_\-\.]+)@[A-Za-z0-9-]+(\.[A-Za-z0-9-]+)*(\.[A-Za-z]{2,3})$";

        public const string ImageValidation = @"^.*\.(jpg|jpeg|gif|JPG|png|PNG)$";

        public const string VideoValidation = @"^([a-zA-Z0-9\s_\\.\-:])+(.mp4|.avi|.mkv)$";
    }

    public class ButtonCss
    {
        public static string btnLoginBlock = "btn btn-lg btn-success btn-block";

        public static string btnSaveLG = "btn btn-lg btn-primary";
        public static string btnSaveMD = "btn btn-md btn-primary";
        public static string btnSaveSM = "btn btn-sm btn-primary";

        public static string btnCancelLG = "btn btn-lg btn-warning";
        public static string btnCancelMD = "btn btn-md btn-warning";
        public static string btnCancelSM = "btn btn-sm btn-warning";

        public static string btnDeleteLG = "btn btn-lg btn-danger";
        public static string btnDeleteMD = "btn btn-md btn-danger";
        public static string btnDeleteSM = "btn btn-sm btn-danger";

        public static string btnExportLG = "btn btn-lg btn-success";
        public static string btnExportMD = "btn btn-md btn-success";
        public static string btnExportSM = "btn btn-sm btn-success";

        public static string btnAddLG = "btn btn-lg btn-primary";
        public static string btnAddMD = "btn btn-md btn-primary";
        public static string btnAddSM = "btn btn-sm btn-primary";

        public static string btnEditLG = "btn btn-lg btn-primary";
        public static string btnEditMD = "btn btn-md btn-primary";
        public static string btnEditSM = "btn btn-sm btn-primary";

        //public ButtonCss();
    }
    public static string AcknwledgementMsg(string Message, out string Class)
    {
        string ReturnMessage = "";
        switch (Message)
        {
            case "Duplicate":
                ReturnMessage = "Sorry, Record Already Exists, hence cannot insert duplicate data.";
                Class = "alert alert-danger alert-dismissable col-lg-12";
                break;
            case "Error":
                ReturnMessage = "Sorry, Error occurred while inserting data.";
                Class = "alert alert-danger alert-dismissable col-lg-12";
                break;
            case "Insert":
                ReturnMessage = "Your request has been sent for approval successfully.";
                Class = "alert alert-success alert-dismissable col-lg-12";
                break;
            case "Update":
                ReturnMessage = "Your record has been updated successfully.";
                Class = "alert alert-success alert-dismissable col-lg-12";
                break;
            case "Delete":
                ReturnMessage = "Your record has been deleted successfully.";
                Class = "alert alert-success alert-dismissable col-lg-12";
                break;
            case "Sort":
                ReturnMessage = "Sort order changed successfully.";
                Class = "alert alert-success alert-dismissable col-lg-12";
                break;
            case "CannotDelete":
                ReturnMessage = "Cannot delete since it is used";
                Class = "alert alert-danger alert-dismissable col-lg-12";
                break;
            case "NoRecord":
                ReturnMessage = "No record found";
                Class = "alert alert-danger alert-dismissable col-lg-12";
                break;
            case "IsNotValid":
                ReturnMessage = "Mandatory fields are compulsory";
                Class = "alert alert-danger alert-dismissable col-lg-12";
                break;
            case "ImageDeleted":
                ReturnMessage = "Image has been deleted successfully.";
                Class = "alert alert-success alert-dismissable col-lg-12";
                break;
            case "VideoDeleted":
                ReturnMessage = "Video has been deleted successfully.";
                Class = "alert alert-success alert-dismissable col-lg-12";
                break;
            case "SameCurrentAndNewPwd":
                ReturnMessage = "Please confirm current password and new password should not be equal.";
                Class = "alert alert-danger alert-dismissable col-lg-12";
                break;
            case "InvalidPwd":
                ReturnMessage = "Invalid current password.";
                Class = "alert alert-danger alert-dismissable col-lg-12";
                break;
            case "PwdUpdated":
                ReturnMessage = "Your password has been updated successfully.";
                Class = "alert alert-success alert-dismissable col-lg-12";
                break;
            case "Restored":
                ReturnMessage = "Your record has been restored successfully.";
                Class = "alert alert-success alert-dismissable col-lg-12";
                break;
            case "CredentialsSent":
                ReturnMessage = "Your account login details has been sent to your email address.";
                Class = "alert alert-success alert-dismissable col-lg-12";
                break;
            case "CredentialsRejected":
                ReturnMessage = "Email address provided by you is not registered with us. Please try again.";
                Class = "alert alert-danger alert-dismissable col-lg-12";
                break;
            case "Invalid":
                ReturnMessage = "Invalid Password.";
                Class = "alert alert-danger alert-dismissable col-lg-12";
                break;


            default:
                ReturnMessage = "";
                Class = "";
                break;
        }
        return ReturnMessage;
    }
    public static string LogsMessage(int Value, string Message = "")
    {
        return Message != "" ? Message : Value == 0 ? LogsAdd : LogsEdit;
    }
}

