using Common.Entity;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public  class LeaveBLL
    {
        public string InsertUpdateUsers(Leaveentiy objUsers)
        {
            return new LeaveDAL().InsertUpdateUsers(objUsers);
        }
        public List<Leaveentiy> ManageUser(Leaveentiy objUser)
        {
            return new LeaveDAL().ManageUser(objUser);
        }

        public int GetCount(string Fromdate, string Todate)
        {
            return new LeaveDAL().GetCount(Fromdate, Todate);

        }
        public int GetCLBalance(string empid)
        {
            return new LeaveDAL().GetCLBalance(empid);
         
        }
        public int GetPLBalance(string empid)
        {
            return new LeaveDAL().GetPLBalance(empid);

        }
        public Leaveentiy DisplayUsers(int leaveid)
        {
            return new LeaveDAL().DisplayUsers(leaveid);
        }
        public string CheckAndDeleteUser(int leaveid)
        {
            return new LeaveDAL().CheckAndDeleteUser(leaveid);
        }
        //public int GetCount(string empid)
        //{
        //    return new LeaveDAL().GetCount(empid);

        //}


    }
}
