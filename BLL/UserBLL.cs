using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public class UserBLL
{
    public string InsertUpdateUsers(UserEntity objUsers)
    {
        return new UserDAL().InsertUpdateUsers(objUsers);
    }

    public List<UserEntity> ManageUser(UserEntity objUser)
    {
        return new UserDAL().ManageUser(objUser);
    }

    public UserEntity DisplayUsers(int UserID)
    {
        return new UserDAL().DisplayUsers(UserID);
    }

    public string CheckAndDeleteUser(int UserId)
    {
        return new UserDAL().CheckAndDeleteUser(UserId);
    }

    public string UpdateUserPassword(string CurrentPwd, string NewPwd, int UserID)
    {
        string ResponseMsg = new UserDAL().UpdateUserPassword(UserID, CurrentPwd, NewPwd);
        return ResponseMsg;
    }
}
