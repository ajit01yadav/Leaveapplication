using System;
using System.Net.Http;
using System.Web.Mvc;

public class AuthenticateDAL
{
    static int intMinutes = 0;

    public static object HttpContext { get; private set; }

    //AuthenticateLogggedIn
    public static void AuthenticateLogggedIn()
    {
        
       if( System.Web.HttpContext.Current.Request.Cookies["User"] == null)

           System.Web.HttpContext.Current.Response.Redirect("Account/Login");
       
        else
        {
            DateTime dtLoginTime = Convert.ToDateTime(System.Web.HttpContext.Current.Request.Cookies["User"]["LogInTime"]);
            intMinutes = CookiesTimeRemaining(dtLoginTime);
            if (intMinutes <= 0)
            {
                var urlHelper = new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext);
                System.Web.HttpContext.Current.Response.Redirect(urlHelper.Action("Login", "Account"));
            }
        }
    }
    public static int CookiesTimeRemaining(DateTime dtLoginTime)
    {
        TimeSpan ts = dtLoginTime.Subtract(DateTime.Now);
        return ts.Minutes;
    }
    //AuthenticateLogggedIn

    public static int UserID()
    {
        AuthenticateLogggedIn();
        return System.Web.HttpContext.Current.Request.Cookies["User"] == null ? 0 : Convert.ToInt32(clsEncrypt.Decrypt(System.Web.HttpContext.Current.Request.Cookies["User"]["UserID"].ToString()));
    }

    public static string FirstName()
    {
        AuthenticateLogggedIn();
        return System.Web.HttpContext.Current.Request.Cookies["User"] == null ? "" : clsEncrypt.Decrypt(System.Web.HttpContext.Current.Request.Cookies["User"]["FirstName"]);
    }

    public static string LastName()
    {
        AuthenticateLogggedIn();
        return System.Web.HttpContext.Current.Request.Cookies["User"] == null ? "" : clsEncrypt.Decrypt(System.Web.HttpContext.Current.Request.Cookies["User"]["LastName"]);
    }
}

