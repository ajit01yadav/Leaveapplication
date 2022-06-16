using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

public class AuthenticateBLL
{
    static int intMinutes = 0;

    //AuthenticateLogggedIn
    public static void AuthenticateLogggedIn()
    {
        AuthenticateDAL.AuthenticateLogggedIn();
    }
   
    public static int UserID()
    {
        return AuthenticateDAL.UserID();
    }

    public static string FirstName()
    {
        return AuthenticateDAL.FirstName();
    }

    public static string LastName()
    {
        return AuthenticateDAL.LastName();
    }
}