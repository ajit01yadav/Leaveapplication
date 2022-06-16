using Common.Entity;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
 public class LoginBLL
    {
        public LoginEntity CheckAndValidateUser(LoginEntity Login)
        {
            return new LoginDAL().CheckAndValidateUser(Login);
        }
    }
}
