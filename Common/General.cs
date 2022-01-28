using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

public class General
{
    public static string GetStatus(int Active)
    {
        if (Active == 1)
            return "Active";
        else
            return "In-Active";
    }

    public static string GetRole(int RoleID)
    {
        if (RoleID == 1)
            return "Admin";
        else
            return "User";
    }

    public List<SelectListItem> getStatus()
    {
        List<SelectListItem> items = new List<SelectListItem>();
        items.Add(new SelectListItem
        {
            Text = "Active",
            Value = "1"
        });
        items.Add(new SelectListItem
        {
            Text = "In-Active",
            Value = "2"
        });
        return items;
    }

    public static string CheckLengthOfPageTitle(string PageTitle)
    {
        int length = 0, maxLength = 30;
        string strPageTitle = "";
        if (PageTitle.Length > 30)
        {
            length = PageTitle.Length;
            strPageTitle = length <= maxLength ? PageTitle : PageTitle.Substring(0, maxLength);
        }
        else
            strPageTitle = PageTitle;
        return strPageTitle;
    }

   

   

  

  

    public static bool HasRights(int Value)
    {
        return Value == 0 ? false : true;
    }

    public static string ConvertToEncrtptVal(string strID)
    {
        return HttpUtility.UrlEncode(clsEncrypt.Encrypt(strID));
    }

    public void SendMail(string ToEmail, string CCEmail, string BCCEmail, string Subject, string Message, int BodyFormat, string ReplyToEmail, bool blnSignature, string FromName)
    {
        try
        {
            string FromEmail = "noreply@unlocktech.in", SMTPUsername = "", SMTPPassword = "", SMTP = "localhost", Signature = "";
            int SMTPPort = 25, EmailAlert = 1;

            if (Signature != "" && blnSignature == true)
                Message = Message + "<br /><span style='line-height: 19px; font-size: 13px;font-family:Arial;'>" + Signature + "</span>";

            if (EmailAlert == 1)
            {
                MailMessage Mailer = new MailMessage();

                if (FromName.Trim() != "")
                    FromEmail = FromName + "<" + FromEmail + ">";

                Mailer.From = new MailAddress(FromEmail);
                Mailer.To.Add(ToEmail);

                if (ReplyToEmail.Length > 0)
                    Mailer.ReplyTo = new MailAddress(ReplyToEmail);

                if (CCEmail.Length > 0)
                    Mailer.CC.Add(CCEmail);

                if (BCCEmail.Length > 0)
                    Mailer.Bcc.Add(BCCEmail);

                Mailer.Subject = Subject;

                if (BodyFormat == 1)
                    Mailer.IsBodyHtml = false;
                else
                    Mailer.IsBodyHtml = true;

                Mailer.Body = Message;

                SmtpClient SmtpMail = new SmtpClient();

                if (SMTPUsername.Trim() != "")
                {
                    System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential(SMTPUsername, SMTPPassword);
                    SmtpMail.UseDefaultCredentials = false;
                    SmtpMail.Credentials = basicAuthenticationInfo;
                }

                SmtpMail.Host = SMTP;

                if (SMTPPort != 0)
                    SmtpMail.Port = SMTPPort;

                SmtpMail.Send(Mailer);
            }
        }
        catch (Exception Ex)
        {
            //throw;
        }
    }


}